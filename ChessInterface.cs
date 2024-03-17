using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ChessDotNet; // Import the Chess.NET library

namespace Move2VoiceBeta
{
    public class ChessInterface
    {
        // Use the ChessGame class from Chess.NET to store the state of the game
        private ChessGame game;

        public ChessInterface()
        {
            // Initialize a new game
            this.game = new ChessGame();
        }

        // Methods to interact with the chess game

        public void MakeMove(Move move)
        {
            // Validate and make a move
            if(game.IsValidMove(move))
            {
                game.MakeMove(move, true);
            }
        }

        public ChessGame GetGameState()
        {
            // Return the current game state
            return this.game;
        }


        public string UciSequenceToPgn(string fen, string[] uciMoves)
        {

            var game = new ChessGame(fen);
            string pgnMoves = "";

            foreach (string uciMove in uciMoves)
            {
                // Parse the UCI string.
                string fromSquare = uciMove.Substring(0, 2);
                string toSquare = uciMove.Substring(2, 2);
                Position from = new Position(fromSquare);
                Position to = new Position(toSquare);

                // Make the move on the game object.
                Move move = new Move(from, to, game.WhoseTurn);
                game.MakeMove(move, true);

                // Get the PGN of the entire game.
                string pgn = game.GetPGN();

                // Parse the PGN string to get the last move.
                string lastMovePgn = pgn.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Last();

                // Append the move to the sequence.
                pgnMoves += lastMovePgn + " ";
            }

            return pgnMoves.Trim();
        }

        public string ExtractMovelist(string text)
        {
            const string startText = "Movelist for game";
            const string endText = "fics%";

            // Find the last occurrence of 'Movelist for game'
            int startPos = text.LastIndexOf(startText);
            if (startPos == -1)
            {
                // 'Movelist for game' was not found in the text
                return null;
            }

            // Find the position of 'fics%' after the last 'Movelist for game'
            int endPos = text.IndexOf(endText, startPos);
            if (endPos == -1)
            {
                // 'fics%' was not found in the text after 'Movelist for game'
                return null;
            }

            // Extract the substring from 'Movelist for game' to 'fics%'
            // We don't include 'Movelist for game' and 'fics%' themselves in the substring
            return text.Substring(startPos + startText.Length, endPos - startPos - startText.Length);
        }


        public string ConvertToPGN(string input)
        {
            string[] lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder pgnBuilder = new StringBuilder();

            // Find move section start index
            int moveSectionStartIndex = Array.FindIndex(lines, line => line.StartsWith("---"));
            if (moveSectionStartIndex == -1)
            {
                return "Move section not found.";
            }

            // Retrieve player names from the line above move section start
            string playerLine = lines[moveSectionStartIndex - 1];
            string[] playerNames = playerLine.Split(new[] { " vs. " }, StringSplitOptions.RemoveEmptyEntries);
            if (playerNames.Length != 2)
            {
                return "Unable to find player names.";
            }

            string whitePlayer = playerNames[0].Trim();
            string blackPlayer = playerNames[1].Trim();

            // Add PGN header
            pgnBuilder.AppendLine("[Event \"Rated standard match\"]");
            pgnBuilder.AppendLine($"[White \"{whitePlayer}\"]");
            pgnBuilder.AppendLine($"[Black \"{blackPlayer}\"]");

            // Extract moves from move section
            pgnBuilder.AppendLine();
            pgnBuilder.AppendLine("[Moves]");

            for (int i = moveSectionStartIndex + 1; i < lines.Length; i++)
            {
                string line = lines[i].Trim();

                if (string.IsNullOrEmpty(line) || line.StartsWith("---"))
                {
                    break;
                }

                string[] moveParts = line.Split(new[] { "  " }, StringSplitOptions.RemoveEmptyEntries);
                if (moveParts.Length >= 4)
                {
                    string moveNumber = moveParts[0].TrimStart('.');
                    string whiteMove = moveParts[1].Trim();
                    string blackMove = moveParts[3].Trim();

                    pgnBuilder.AppendLine($"{moveNumber}. {whiteMove} {blackMove}");
                }
            }

            return pgnBuilder.ToString().Trim();
        }


        public string Style12ToFEN(string style12)
        {
            try
            {
                int charPos = style12.IndexOf("<12>");
                if (charPos == -1)
                {
                    throw new ArgumentException("The input string does not contain the expected '<12>' string.", nameof(style12));
                   
                }

                style12 = style12.Substring(charPos);
                var parts = style12.Split(' ');

                if (parts.Length < 30)
                {
                    throw new ArgumentOutOfRangeException(nameof(style12), "The input string does not contain enough parts to generate a FEN string.");
                }

                // Parse the board layout
                var boardLayoutParts = parts.Skip(1).Take(8).ToList();

                StringBuilder fenBuilder = new StringBuilder();
                int emptyCounter = 0;
                int rank = 8;

                foreach (var part in boardLayoutParts)
                {
                    foreach (char c in part)
                    {
                        if (c == '-')
                        {
                            emptyCounter++;
                        }
                        else
                        {
                            AppendEmptyCounterAndReset(ref emptyCounter, fenBuilder);
                            fenBuilder.Append(c);
                        }
                    }

                    AppendEmptyCounterAndReset(ref emptyCounter, fenBuilder);

                    if (--rank > 0) fenBuilder.Append('/');
                }

                // Parse other details
                var activeColor = parts[9] == "B" ? "b" : "w";
                var castlingAvailability = "";

                if (parts[11] == "1") castlingAvailability += "K";
                if (parts[12] == "1") castlingAvailability += "Q";
                if (parts[13] == "1") castlingAvailability += "k";
                if (parts[14] == "1") castlingAvailability += "q";

                if (castlingAvailability == "") castlingAvailability = "-";

                var enPassantTargetSquare = "-";
                if (parts[10] != "-1")
                {
                    int fileIndex = Int32.Parse(parts[10]);
                    char file = (char)('a' + fileIndex);
                    char rankChar = activeColor == "b" ? '6' : '3';
                    enPassantTargetSquare = $"{file}{rankChar}";
                }

                var halfmoveClock = parts[15];
                var fullmoveNumber = parts[29];

                // Assemble the FEN string
                var fen = $"{fenBuilder.ToString()} {activeColor} {castlingAvailability} {enPassantTargetSquare} {halfmoveClock} {fullmoveNumber}";

                return fen;
            }
            catch
            {
                // If the function encounters an error, it returns an empty string.
                // Depending on your use case, you might want to change this behavior.
                return "";
            }
        }

        private void AppendEmptyCounterAndReset(ref int emptyCounter, StringBuilder fenBuilder)
        {
            if (emptyCounter > 0)
            {
                fenBuilder.Append(emptyCounter);
                emptyCounter = 0;
            }
        }





        public char[,] FenToBoard(string fen)
        {
            try {
                    var fenParts = fen.Split(' ');
                    var boardString = fenParts[0];
                    var boardRows = boardString.Split('/');
                    var board = new char[8, 8];

                    for (int i = 0; i < 8; i++)
                    {
                        int col = 0;
                        foreach (var c in boardRows[i])
                        {
                            if (char.IsDigit(c)) // empty squares
                            {
                                int emptySquares = int.Parse(c.ToString());
                                for (int j = 0; j < emptySquares; j++)
                                {
                                    board[i, col] = '-';
                                    col++;
                                }
                            }
                            else // piece
                            {
                                board[i, col] = c;
                                col++;
                            }
                        }
                    }

                    return board;
            }
            catch
            {
                // If the function encounters an error, it returns an empty string.
                // Depending on your use case, you might want to change this behavior.
                return null;
            }
        }


      


        public string MakeFen(string s)
        {
            int charPos = s.IndexOf("<12>");
           // if (charPos == -1) return;

            string gameString = s.Substring(charPos + 4);
            StringBuilder fenBuilder = new StringBuilder();

            int rank = 8;
            int emptyCounter = 0;
            foreach (char c in gameString)
            {
                if (c == '-')
                {
                    emptyCounter++;
                }
                else if (c == ' ')
                {
                    AppendEmptyCounterAndReset(ref emptyCounter, fenBuilder);

                    if (--rank > 0) fenBuilder.Append('/');
                }
                else
                {
                    AppendEmptyCounterAndReset(ref emptyCounter, fenBuilder);
                    fenBuilder.Append(c);
                }
            }

            // Ensure the last empty spaces are added
            AppendEmptyCounterAndReset(ref emptyCounter, fenBuilder);

            // Assuming the side to move is always white
            string fen = $"{fenBuilder} w KQkq - 0 1";
            return fen;
  
        }

       











        // Add more methods as needed for your interface...
    }
}

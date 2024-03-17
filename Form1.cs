using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Move2VoiceBeta
{
    public partial class FrmMain : Form
    {
        TelnetConnection tc = new TelnetConnection("freechess.org", 5000);
        string prompt = string.Empty;
        public string tmp = string.Empty;
        public int speechrate = 0;
        public bool engine_runnig = false;
        public bool engine_enabled = true;
        public string sentence = string.Empty;
        string squareName = string.Empty;
        private char[,] board = new char[8, 8];
        private int[] currentSquare = new int[] { 0, 1 };
        private Engine engine;
        string sideToMove = string.Empty;
        string whitePlayer = string.Empty;
        string blackPlayer = string.Empty;
        string amIPlaying = string.Empty;
        string whitesRemainingTime = string.Empty;
        string blacksRemainingTime = string.Empty;
        string lastMove = string.Empty;
        private SpeechQueue speechQueue;
        bool amAtBoard = false;
        bool whiteToMove = true;
        string currentMoveNumber = string.Empty;
        string gamestate = string.Empty;
        bool tab = false;
        bool noMovesReading = true;
        public bool MovesTaken = false;
        public string allHistory = string.Empty;
        int numberOfLinesRead = 0;
        bool lookForSquare = false;
        bool altPressed = false;
        int lastInputLineIndex = 0;
        List<string[]> games = new List<string[]>();
		public string lastResponse = string.Empty;


        public FrmMain()
        {
            InitializeComponent();
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;
            this.Width = Screen.PrimaryScreen.Bounds.Width - 50;
            this.Height = Screen.PrimaryScreen.Bounds.Height + 50;
            this.StartPosition = FormStartPosition.CenterScreen;
            pnlServer.Width = this.Width - 550;
            rtbMainConsole.Width = this.Width - 580 - dataGridView2.Width;
            dataGridView2.Top = rtbMainConsole.Top;
            dataGridView2.Left = rtbMainConsole.Left + rtbMainConsole.Width + 20;
            dgvGames.Top = dataGridView2.Bottom;
            dgvGames.Left = dataGridView2.Left;
            this.KeyPreview = true;
            var fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
            ChessInterface ci = new ChessInterface();
            var board = ci.FenToBoard(fen);
            DisplayBoard(board);
            this.Load += FrmMain_Load;  // Add a handler for the Load event
            this.tbUser.Enter += new EventHandler(tbUser_Enter);
            // this.richTextBox2.Enter += new EventHandler(richTextBox2_KeyDown);
            engine = new Engine(this); // Pass the instance of FrmMain to the Engine class
            speechQueue = new SpeechQueue(-1);
            speechQueue.LogNeeded += AppendLog;
            pnlServer.Width = this.Width - 550;
            rtbMainConsole.Width = Convert.ToInt32(pnlServer.Width * 0.6);
            dataGridView2.Width = Convert.ToInt32(pnlServer.Width * 0.4);
            dataGridView2.Left = rtbMainConsole.Width + 10;
            dgvGames.Width = dataGridView2.Width;
            pnlEngineAndCommunication.Width = pnlServer.Width;

        }


        private PictureBox CurrentPictureBox
        {
            get { return (PictureBox)pnlBoard.Controls[((char)('a' + currentSquare[0])) + currentSquare[1].ToString()]; }
        }
        private string CurrentSquareName
        {
            get { return (char)('a' + currentSquare[0]) + currentSquare[1].ToString(); }
        }


        private void FrmMain_Load(object sender, EventArgs e)
        {

            tbUser.Focus();  // Now the call to Focus() will work as expected
            tbUser.SelectAll();

        }
        public static void WriteIniFile(string path, string username, string password)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("[User]");
                sw.WriteLine(username);
                sw.WriteLine("[Password]");
                sw.WriteLine(password);
            }
        }
        public static (string, string) ReadIniFile(string path)
        {
            string username = null;
            string password = null;

            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line == "[User]")
                    {
                        username = sr.ReadLine();
                    }
                    else if (line == "[Password]")
                    {
                        password = sr.ReadLine();
                    }
                }
            }

            return (username, password);
        }

        private void Login()
        {

            //Code for saving pwd etc
        }

        private void ReconnectToTelnetServer()
        {
            try
            {
                // Close the existing connection if it's still open
                if (tc.IsConnected)
                    tc.Close();

                // Create a new instance of TelnetConnection
                tc = new TelnetConnection("freechess.org", 5000);

                // Perform any login or initialization steps as needed

                // Continue communication with the telnet server
                // You can start sending commands or performing other operations
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during reconnection
                // You can log the error, display a message to the user, or take appropriate action
            }
        }


        private async void Send(string s)
        {
            lastInputLineIndex = rtbMainConsole.Lines.Count() - 1;
            string controlVariable = "Execute"; // default
            if (s.StartsWith("/"))
            {
                altPressed = true;
                s = s.Substring(1);


            }


            if (altPressed)
            {
                controlVariable = "DoNotSend";




                if (s == "p")
                {

                    FocusEachPictureBoxSequentially("p");
                    tbPrompt.Focus();

                }

                if (s == "r")
                {
                    FocusEachPictureBoxSequentially("r");
                    tbPrompt.Focus();

                }
                if (s == "n")
                {
                    FocusEachPictureBoxSequentially("n");
                    tbPrompt.Focus();

                }
                if (s == "b")
                {

                    FocusEachPictureBoxSequentially("b");
                    tbPrompt.Focus();

                }
                if (s == "q")
                {
                    controlVariable = "DoNotSend";
                    FocusEachPictureBoxSequentially("q");
                    tbPrompt.Focus();

                }
                if (s == "k")
                {

                    FocusEachPictureBoxSequentially("k");
                    tbPrompt.Focus();

                }

                if (s == "t")
                {

                    speechQueue.EnqueueSpeech("Whites remaining time:" + lblWhitesRemainingTimeFormated.Text);
                    speechQueue.EnqueueSpeech("Blacks remaining time:" + lblBlacksRemainingTimeFormated.Text);
                }

                if (s == "wplayer")
                {

                    speechQueue.EnqueueSpeech("Playing white:" + lblWhitePlayer.Text);

                }
                if (s == "bplayer")
                {

                    speechQueue.EnqueueSpeech("Playing black:" + lblBlackPlayer.Text);
                }

                if (s == "h")
                {
                    rtbMainConsole.Focus();
                    int lastLineIndex = rtbMainConsole.Lines.Length - 1;
                    int start = rtbMainConsole.GetFirstCharIndexFromLine(lastLineIndex);  // Get the start of the last line
                    int length = rtbMainConsole.Lines[lastLineIndex].Length;  // Get the length of the last line
                    rtbMainConsole.Select(start, length);  // Select the last line
                    speechQueue.EnqueueSpeech("Use arrows to navigate. Ctrl stops the voice. Tab will bring you back to the prompt where you type commands");
                }

                if (s == "m")

                {

                    string lastLine = string.Empty;

                    this.Invoke((MethodInvoker)delegate
                    {
                        // assuming that 'this' is the Form that contains the RichTextBox
                        if (rtbGameMovesVerbose.Lines.Length > 0)
                        {
                            lastLine = rtbGameMovesVerbose.Lines[rtbGameMovesVerbose.Lines.Length - 2];
                            //	MessageBox.Show("Line count: " + (rtbGameMovesVerbose.Lines.Length - 2).ToString());
                            //MessageBox.Show("Last line: '" + lastLine + "'");
                        }
                        else
                        {
                            MessageBox.Show("No lines in the RichTextBox");
                        }
                    });

                    speechQueue.EnqueueSpeech(lastLine);
                }
                if (s.Length == 2)
                {
                    bool isItaSquare = CheckIfSquareIsRequested(s);
                    if (isItaSquare)
                    {
                        lookForSquare = true;
                        tbSquareName.Text = s;
                    }
                }


                altPressed = false;
            } //**












            if (s == "moves")
            {
                controlVariable = "DoNotSend";
                MovesTaken = true;
                //controlVariable = "s";
                noMovesReading = false;
                tc.WriteLine(s);
                dataGridView2.Rows.Clear();
                // lastResponse = tc.Read();
                string data = tc.Read(); // the data string
                allHistory += data;

                //Clipboard.SetText(data); //for debugging
                bool startAdding = false;
                using (StringReader sr = new StringReader(data))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains("1. "))
                        {
                            startAdding = true;
                        }
                        if (line.Contains("{"))
                        {
                            startAdding = false;
                        }

                        if (startAdding)
                        {
                            string[] splitLine = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            if (splitLine.Length > 0)
                            {

                                dataGridView2.Rows.Add(splitLine);


                            }
                        }
                    }
                }

                // Get the last non-empty row
                int lastRow = dataGridView2.Rows.Count - 1;
                while (lastRow >= 0 && dataGridView2.Rows[lastRow].Cells[1].Value == null)
                {
                    lastRow--;
                }

                if (lastRow >= 0)  // If there is at least one row
                {
                    // If column 1 is populated but not column 3
                    if (dataGridView2.Rows[lastRow].Cells[1].Value != null && dataGridView2.Rows[lastRow].Cells[3].Value == null)
                    {
                        dataGridView2.CurrentCell = dataGridView2.Rows[lastRow].Cells[1]; // Enter cell in column 1
                    }
                    else
                    {
                        dataGridView2.CurrentCell = dataGridView2.Rows[lastRow].Cells[3]; // Enter cell in column 3
                    }
                }

                dataGridView2.Refresh();
                tbPrompt.Focus();
            }
           





            switch (controlVariable)
            {
                case "Execute":

                    if (tc.IsConnected && tbPrompt.Text != "exit")
                    {
                        speechQueue.EnqueueSpeech(s);
                        tc.WriteLine(s);
                        rtbMainConsole.Text += s + Environment.NewLine;
                        lastResponse = tc.Read();
                        allHistory += lastResponse;
                    }
                    if (lastResponse.Contains("<12>"))
                    {
                        lastResponse = lastResponse.Replace("fics%", "")
                                                                 .Replace("/", "")
                                                                 .Replace("\\", "")
                                                                 .TrimEnd('\r', '\n');
                        rtbLogGamestring.Text += lastResponse;
                    }
                    else
                    {
                        lastResponse = lastResponse.Replace("fics%", "")
                                                                 .Replace("/", "")
                                                                 .Replace("\\", "")
                                                                 .TrimEnd('\r', '\n');
                        rtbMainConsole.Text += lastResponse;
                        speechQueue.EnqueueSpeech(lastResponse);
                    }
                    rtbMainConsole.SelectionStart = rtbMainConsole.Text.Length;
                    rtbMainConsole.ScrollToCaret();

                    break;

                case "DoNotSend":
                    // In this case, do nothing.
                    break;

                default:
                    // This block can be used to handle unexpected values of controlVariable.
                    // It's optional and can be removed if not needed.
                    break;
            }

            rtbMainConsole.SelectionStart = rtbMainConsole.Text.Length;
            rtbMainConsole.ScrollToCaret();
            //tbPrompt.Focus();
            if (s == "games")
            {
                dgvGames.Rows.Clear();
                dgvGames.Refresh();
                games.Clear();
                await Task.Delay(1000);// delay for the tc thread to catchup (probably need better solution)
                int lastLineIndex = lastInputLineIndex + 3; // start parsing on the line where the games start
                while (rtbMainConsole.Lines[lastLineIndex] != string.Empty)
                {
                    // removes uneccessary whitespaces and splits the line
                    string[] row = rtbMainConsole.Lines[lastLineIndex].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    List<string> gameData = row.Take(5).ToList(); // takes player info
                    bool readingTypeData = false;
                    List <string> typeData = new List<string>();
                    foreach(string data in row)
                    {
                        if (data.Contains("["))
                            readingTypeData = true;
                        if (readingTypeData)
                            typeData.Add(data);
                        if (data.Contains("]"))
                            break;
                    }
                    string typeDataString = String.Join("+", typeData.Select(x => x.Replace("]", "").Replace("[", ""))).Trim('+');
                    var regex = new Regex(Regex.Escape("+"));
                    typeDataString = regex.Replace(typeDataString, " ", 1);
                    gameData.Add(typeDataString);
                    dgvGames.Rows.Add(gameData.ToArray()); // pushes to new row in grid
                    games.Add(gameData.ToArray());
                    lastLineIndex +=2;

                }
            }
        }


        private bool CheckIfSquareIsRequested(string s)
        {
            char firstChar = s[0];
            char secondChar = s[1];
            return (firstChar >= 'a' && firstChar <= 'h') && (secondChar >= '1' && secondChar <= '8');
        }





        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }
        private void Connect()
        {
            lastResponse = tc.Read();
            allHistory += lastResponse;
            rtbMainConsole.Text += lastResponse.Replace("fics%", "");
            rtbMainConsole.SelectionStart = rtbMainConsole.Text.Length;
            rtbMainConsole.ScrollToCaret();
            // Check for empty username and password first.
            if (string.IsNullOrEmpty(tbUser.Text) || string.IsNullOrEmpty(tbPassword.Text))
            {
                tbUser.Text = "guest";
            }

            lastResponse = tc.Read();
            allHistory += lastResponse;
            rtbMainConsole.Text += lastResponse.Replace("fics%", "");
            rtbMainConsole.SelectionStart = rtbMainConsole.Text.Length;
            rtbMainConsole.ScrollToCaret();
            string s = tc.Login(tbUser.Text, tbPassword.Text, 100);
            lastResponse = tc.Read();
            allHistory += lastResponse;
            rtbMainConsole.Text += lastResponse.Replace("fics%", "");
            rtbMainConsole.SelectionStart = rtbMainConsole.Text.Length;
            rtbMainConsole.ScrollToCaret();
            string ts = tc.IsConnected ? "CONNECTED" : "NOT CONNECTED";
            speechQueue.EnqueueSpeech(ts);
            rtbMainConsole.Text += ts + Environment.NewLine;
            lastResponse = tc.Read();
            allHistory += lastResponse;
            rtbMainConsole.Text += lastResponse.Replace("fics%", "");
            speechQueue.EnqueueSpeech(ts);
            lastResponse = tc.Read();
            allHistory += lastResponse;
            tmrRead.Enabled = true;
            btnRead.BackColor = Color.Green;
            tbPrompt.Focus();
            Send("set style 12");
            Send("set seek 0");
            rtbMainConsole.Text += lastResponse.Replace("fics%", ""); ;
            rtbMainConsole.SelectionStart = rtbMainConsole.Text.Length;
            rtbMainConsole.ScrollToCaret();
            speechQueue.Dequeue();

        }

        private void tbPrompt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    tbPrompt.Focus();

                    // Send a dummy key event to the application.
                    SendKeys.Send("{RIGHT}");
                });

            }

            Speech speech = new Speech((int)nudSpeachrate.Value, 50);

            if (!checkBox1.Checked)
            {
                speech.Mute();
            }

            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                char keyChar = (char)('0' + (e.KeyCode - Keys.D0));
                //  speech.SpeakAsync(keyChar.ToString());
            }
            else
            {
                speech.SpeakAsync(e.KeyCode.ToString());

            }

            // speechQueue.EnqueueSpeech(e.KeyCode.ToString());
            if (e.KeyCode.ToString() == "Return")
            {

                Send(tbPrompt.Text);
                tbPrompt.Text = string.Empty;
            }


        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Send(tbPrompt.Text);
        }




        string myGameNumber = string.Empty;
        string gameToLoookFor = string.Empty;


        public void ExtractFields(string s)
        {
            string colorToMove = string.Empty;
            richTextBox1.Clear();
            richTextBox2.Clear();
            int startPos = s.LastIndexOf("<12>");
            int row = 0;

            string stmp = s.Substring(startPos);
            label1.Text = stmp;
            // Splitting the string into parts using the space character as a delimiter
            var parts = stmp.Split(' ');
            foreach (string part in parts)
            {
                if (row > 0 && row < 9)
                {
                    richTextBox2.Text += part + Environment.NewLine;
                }
                richTextBox1.Text += row.ToString() + " " + part + Environment.NewLine;
                row++;
            }
            // Extracting the fields
            sideToMove = parts[9];
            if (sideToMove == "W")
            {
                whiteToMove = false;
                colorToMove = "Black ";
            }
            else
            {
                whiteToMove = true;
                colorToMove = "White ";

            }
            amIPlaying = parts[19];
            myGameNumber = parts[16];
            if (myGameNumber.Length == 0)
            {
                myGameNumber = "-1"; // this is to ensure that you dont get any unwanted game info

            }
            gameToLoookFor = "{Game " + myGameNumber;
            whitePlayer = parts[17];
            blackPlayer = parts[18];
            currentMoveNumber = parts[26];
            if (amIPlaying == "-1" || amIPlaying == "1")
            {
                btnStartEngine.Enabled = false;
                btnStartEngine.BackColor = Color.Red;

            }
            else
            {
                btnStartEngine.Enabled = true;
                btnStartEngine.BackColor = Color.Green;
            }

            whitesRemainingTime = parts[24];
            blacksRemainingTime = parts[25];
            lastMove = parts[27];

            //Speech speech = new Speech((int)nudSpeachrate.Value);
            sentence = InterpretLastMove(lastMove, whiteToMove);
            if (lastMove == "o-o")
            {
                sentence = colorToMove + "castles Kingside";
            }
            else if (lastMove == "o-o-o")
            {
                sentence = colorToMove + "castles Queenside";
            }
            //sentence = ConvertDigitsToWords(sentence);
            if (!whiteToMove)
            {
                int cm = 0;
                cm = Convert.ToInt32(currentMoveNumber);
                cm--;
                currentMoveNumber = ConvertDigitsToWords(cm.ToString());
                // there is a bug on the serverside that does not add 1 to the 
                //movenumber on whites turn, this bug occurs strangely enough only after move 1,
                // which means further handling but this will do for now, the movenumber is read
                // correctly after move 2. I will check with FICS
                // 
            }



            lblsideToMove.Text = sideToMove;
            lblWhitePlayer.Text = whitePlayer;
            lblBlackPlayer.Text = blackPlayer;
            lblAmIPlaying.Text = amIPlaying;
            lblWhitesRemainingTime.Text = whitesRemainingTime;
            lblBlacksRemainingTime.Text = blacksRemainingTime;
            // Here i take care of the movelisting

        }


        public string GetCurrentPositionPiecePlacement(RichTextBox rtb, string squareName)
        {
            Dictionary<char, string> pieceTranslationDictionary = new Dictionary<char, string>
            {
                {'r', "Black Rook"},
                {'n', "Black Knight"},
                {'b', "Black Bishop"},
                {'q', "Black Queen"},
                {'k', "Black King"},
                {'p', "Black Pawn"},
                {'R', "White Rook"},
                {'N', "White Knight"},
                {'B', "White Bishop"},
                {'Q', "White Queen"},
                {'K', "White King"},
                {'P', "White Pawn"},
                {'-', ""}
            };
            string pieceX = string.Empty;
            string[] lines = rtb.Lines;
            string[,] boardPosition = new string[8, 8];

            for (int i = 0; i < 8; i++)
            {
                string line = lines[i];
                for (int j = 0; j < 8; j++)
                {
                    char pieceChar = line[j];
                    string pieceName = pieceTranslationDictionary[pieceChar];
                    string squareNameTemp = $"{(char)('a' + j)}{8 - i}";
                    boardPosition[j, 8 - i - 1] = pieceName;

                    if (squareNameTemp == squareName)
                    {
                        pieceX = ($"pieceName: {pieceName}");
                        return pieceX;
                    }
                }
            }

            throw new Exception($"Square name {squareName} not found on the board.");
        }


        private object[] ParseAndAssignLinesFromRichTextBox(string line)
        {
            try
            {
                // Split the line into parts
                string[] parts = line.Split(' ');

                // Assign parts to variables
                int cpEvaluation = int.Parse(parts[9]);
                // Get the pv moves (pv1, pv2, pv3, etc)
                List<string> pvMoves = new List<string>();
                for (int i = 19; i < parts.Length; i++)
                {
                    pvMoves.Add(parts[i]);
                }

                string pvMovesString = String.Join(" ", pvMoves);

                // Convert pvMoves List to array


                // Create an array of objects to return
                object[] values = new object[] { cpEvaluation, pvMovesString };

                return values;
            }
            catch (Exception ex)
            {
                // Log the error or silently ignore it, depends on your needs
                // (ex.ToString());
                return null;
            }
        }
        private string ParseAndAssignLinesFromRichTextBox2(string line)
        {
            try
            {
                // Split the line into parts
                string[] parts = line.Split(' ');

                // Assign parts to variables
                int cpEvaluation = int.Parse(parts[9]);
                // Get the pv moves (pv1, pv2, pv3, etc)
                List<string> pvMoves = new List<string>();

                string theMove = parts[19];
                //Here the conversion to verbose pgn should take place
                // Convert pvMoves List to array




                return cpEvaluation.ToString() + theMove;
            }
            catch (Exception ex)
            {
                // Log the error or silently ignore it, depends on your needs
                // (ex.ToString());
                return null;
            }
        }




        private string FormatTime(int seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            string timeFormatted = time.ToString(@"hh\:mm\:ss");
            return timeFormatted;
        }
        private string InterpretLastMove(string s, bool isWhitesTurn)
        {
            Dictionary<string, string> replacementTextWhite = new Dictionary<string, string>()
        {
        { "K/", "White King   " },{ "Q/", "White Queen   " }, { "R/", "White Rook   " }, { "B/", "White Bishop " },{ "N/", "White Night   " },{ "P/", "White Pawn  " },
        };


            Dictionary<string, string> replacementTextBlack = new Dictionary<string, string>()
        {
        { "K/", "Black King " },{ "Q/", "Black Queen  " }, { "R/", "Black Rook  " }, { "B/", "Black Bishop  " },{ "N/", "Black Night  " },{ "P/", "Black Pawn  " },
        };

            string key = s.Substring(0, 2); // Get the first two characters of the input string

            if (isWhitesTurn)
            {
                if (replacementTextWhite.TryGetValue(key, out string replacement))
                {
                    s = replacement + " " + s.Substring(2); // Replace the key with the corresponding value
                    label2.Text = s;
                }
                else
                {
                    s = string.Empty; // No match found, set the string to empty
                }
            }
            else
            {
                if (replacementTextBlack.TryGetValue(key, out string replacement))
                {
                    s = replacement + " " + s.Substring(2); // Replace the key with the corresponding value
                    label2.Text = s;
                }
                else
                {
                    s = string.Empty; // No match found, set the string to empty
                }
            }

            return s;
        }


        private string ConvertDigitsToWords(string input)
        {



            string[] digitWords = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] tensWords = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] teensWords = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };


            string result = "";
            try
            {
                int[] digits = input.Select(c => int.Parse(c.ToString())).ToArray();
                int numDigits = digits.Length;

                for (int i = 0; i < numDigits; i++)
                {
                    int digit = digits[i];
                    int position = numDigits - i;

                    if (position == 2)
                    {
                        if (digit == 1 && i + 1 < numDigits)
                        {
                            int nextDigit = digits[i + 1];
                            result += teensWords[nextDigit] + " ";
                            i++; // Skip the next digit since it has been handled
                        }
                        else
                        {
                            result += tensWords[digit] + " ";
                        }
                    }
                    else if (position == 1)
                    {
                        result += digitWords[digit] + " ";
                    }
                    else if (position == 3)
                    {
                        result += digitWords[digit] + "hundred ";
                    }
                    else if (position > 3)
                    {
                        result += digitWords[digit] + "thousand ";
                    }
                }

                return result.Trim();
            }
            catch (Exception ex)
            {
                return input;
            }

        }




        private void ObserveGame()
        {


            string test = string.Empty;
            ChessInterface ci = new ChessInterface();
            tbGameString.Text = ci.Style12ToFEN(lastResponse);
            ExtractFields(lastResponse);
            lastResponse = string.Empty; // took a while but eventually i found the logical error, the string must be emtied here otherwise the timer will accept lastResponse as indata twice, the delay and speech are to be watch out for /LNO
            var fen = tbGameString.Text;
            var board = ci.FenToBoard(fen);
            if (cbReverseBoard.Checked)
            {
                UpdateReversedBoard(board);
            }
            else
            {
                UpdateBoard(board);
            }

            speechQueue.EnqueueSpeech(currentMoveNumber + " " + sentence);
            rtbGameMovesVerbose.Text += currentMoveNumber + " " + sentence + Environment.NewLine;





        }




        private void button1_Click(object sender, EventArgs e)
        {
            //button Should be removed , no function
            ChessInterface ci = new ChessInterface();
            tbGameString.Text = ci.Style12ToFEN(lastResponse);
            Speech speech = new Speech((int)nudSpeachrate.Value, 50);
            speech.SpeakAsync("Converted to fen");
            var fen = tbGameString.Text;
            var board = ci.FenToBoard(fen);
            UpdateBoard(board);

        }
        Color darkBrown = Color.FromArgb(132, 71, 10);
        Color lightBrown = Color.FromArgb(250, 245, 200);
        public void DisplayBoard(char[,] board)
        {
            // here i want to make a 2 dimensional array to use for the reversed board
            try
            {
                int squareSize = 60;
                int tabIndex = 0;

                // clear the panel
                pnlBoard.Controls.Clear();

                for (int i = 0; i < 8; i++)
                {

                    for (int j = 0; j < 8; j++)
                    {
                        var pictureBox = new SelectablePictureBox
                        {
                            TabIndex = tabIndex++,
                            Width = squareSize,
                            Height = squareSize,
                            Location = new Point((j * squareSize) + 10, (i * squareSize) + 10),
                            BorderStyle = BorderStyle.FixedSingle,
                            BackColor = (i + j) % 2 == 0 ? lightBrown : darkBrown,
                            SizeMode = PictureBoxSizeMode.CenterImage,
                            Tag = $"{(char)('a' + j)}{8 - i}",
                            Name = $"{(char)('a' + j)}{8 - i}",
                            AccessibleDescription = $"{(char)('a' + j)}{8 - i}",
                            TabStop = true,

                        };

                        switch (board[i, j])
                        {
                            case 'r':
                                pictureBox.Image = imageList1.Images[0];
                                break;
                            case 'n':
                                pictureBox.Image = imageList1.Images[1];
                                break;
                            case 'b':
                                pictureBox.Image = imageList1.Images[2];
                                break;
                            case 'q':
                                pictureBox.Image = imageList1.Images[3];
                                break;
                            case 'k':
                                pictureBox.Image = imageList1.Images[4];
                                break;
                            case 'p':
                                pictureBox.Image = imageList1.Images[5];
                                break;
                            case 'R':
                                pictureBox.Image = imageList1.Images[6];
                                break;
                            case 'N':
                                pictureBox.Image = imageList1.Images[7];
                                break;
                            case 'B':
                                pictureBox.Image = imageList1.Images[8];
                                break;
                            case 'Q':
                                pictureBox.Image = imageList1.Images[9];
                                break;
                            case 'K':
                                pictureBox.Image = imageList1.Images[10];
                                break;
                            case 'P':
                                pictureBox.Image = imageList1.Images[11];
                                break;

                            case '-':
                                pictureBox.Image = null;
                                break;
                        }

                        // add the PictureBox to the panel
                        pnlBoard.Controls.Add(pictureBox);
                        pictureBox.Click += PictureBox_Click;
                        pictureBox.Enter += PictureBox_Enter;
                        pictureBox.Leave += PictureBox_Leave;
                        pictureBox.MouseEnter += PictureBox_MouseEnter;
                        pictureBox.MouseLeave += PictureBox_MouseLeave;
                        pictureBox.KeyDown += PictureBox_KeyDown;
                    }
                }
            }
            catch
            {
                // If the function encounters an error, handle it accordingly.
            }
        }
        public void UpdateBoard(char[,] board)
        {
            try
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        string pictureBoxName = $"{(char)('a' + j)}{8 - i}";
                        PictureBox pictureBox = (PictureBox)pnlBoard.Controls[pictureBoxName];

                        if (pictureBox != null)
                        {
                            switch (board[i, j])
                            {
                                case 'r':
                                    pictureBox.Image = imageList1.Images[0];
                                    pictureBox.Tag = $"Black Rook {pictureBoxName}";
                                    break;
                                case 'n':
                                    pictureBox.Image = imageList1.Images[1];
                                    pictureBox.Tag = $"Black Knight {pictureBoxName}";
                                    break;
                                case 'b':
                                    pictureBox.Image = imageList1.Images[2];
                                    pictureBox.Tag = $"Black Bishop {pictureBoxName}";
                                    break;
                                case 'q':
                                    pictureBox.Image = imageList1.Images[3];
                                    pictureBox.Tag = $"Black Queen {pictureBoxName}";
                                    break;
                                case 'k':
                                    pictureBox.Image = imageList1.Images[4];
                                    pictureBox.Tag = $"Black King {pictureBoxName}";
                                    break;
                                case 'p':
                                    pictureBox.Image = imageList1.Images[5];
                                    pictureBox.Tag = $"Black Pawn {pictureBoxName}";
                                    break;
                                case 'R':
                                    pictureBox.Image = imageList1.Images[6];
                                    pictureBox.Tag = $"White Rook {pictureBoxName}";
                                    break;
                                case 'N':
                                    pictureBox.Image = imageList1.Images[7];
                                    pictureBox.Tag = $"White Knight {pictureBoxName}";
                                    break;
                                case 'B':
                                    pictureBox.Image = imageList1.Images[8];
                                    pictureBox.Tag = $"White Bishop {pictureBoxName}";
                                    break;
                                case 'Q':
                                    pictureBox.Image = imageList1.Images[9];
                                    pictureBox.Tag = $"White Queen {pictureBoxName}";
                                    break;
                                case 'K':
                                    pictureBox.Image = imageList1.Images[10];
                                    pictureBox.Tag = $"White King {pictureBoxName}";
                                    break;
                                case 'P':
                                    pictureBox.Image = imageList1.Images[11];
                                    pictureBox.Tag = $"White Pawn {pictureBoxName}";
                                    break;
                                case '-':
                                    pictureBox.Image = null;
                                    pictureBox.Tag = pictureBoxName;
                                    break;
                            }
                        }
                    }
                }
                // we might want to display the reversed board in a small panel
                pnlBoard.Refresh();
            }
            catch
            {
                // If the function encounters an error, you might want to handle it accordingly.
            }
        }


        public void UpdateReversedBoard(char[,] board)
        {
            try
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        string pictureBoxName = $"{(char)('h' - j)}{8 - i}";
                        PictureBox pictureBox = (PictureBox)pnlBoard.Controls[pictureBoxName];

                        if (pictureBox != null)
                        {
                            switch (board[7 - i, 7 - j]) // Reversed row and column index
                            {
                                case 'r':
                                    pictureBox.Image = imageList1.Images[0];
                                    pictureBox.Tag = $"Black Rook {pictureBoxName}";
                                    break;
                                case 'n':
                                    pictureBox.Image = imageList1.Images[1];
                                    pictureBox.Tag = $"Black Knight {pictureBoxName}";
                                    break;
                                case 'b':
                                    pictureBox.Image = imageList1.Images[2];
                                    pictureBox.Tag = $"Black Bishop {pictureBoxName}";
                                    break;
                                case 'q':
                                    pictureBox.Image = imageList1.Images[3];
                                    pictureBox.Tag = $"Black Queen {pictureBoxName}";
                                    break;
                                case 'k':
                                    pictureBox.Image = imageList1.Images[4];
                                    pictureBox.Tag = $"Black King {pictureBoxName}";
                                    break;
                                case 'p':
                                    pictureBox.Image = imageList1.Images[5];
                                    pictureBox.Tag = $"Black Pawn {pictureBoxName}";
                                    break;
                                case 'R':
                                    pictureBox.Image = imageList1.Images[6];
                                    pictureBox.Tag = $"White Rook {pictureBoxName}";
                                    break;
                                case 'N':
                                    pictureBox.Image = imageList1.Images[7];
                                    pictureBox.Tag = $"White Knight {pictureBoxName}";
                                    break;
                                case 'B':
                                    pictureBox.Image = imageList1.Images[8];
                                    pictureBox.Tag = $"White Bishop {pictureBoxName}";
                                    break;
                                case 'Q':
                                    pictureBox.Image = imageList1.Images[9];
                                    pictureBox.Tag = $"White Queen {pictureBoxName}";
                                    break;
                                case 'K':
                                    pictureBox.Image = imageList1.Images[10];
                                    pictureBox.Tag = $"White King {pictureBoxName}";
                                    break;
                                case 'P':
                                    pictureBox.Image = imageList1.Images[11];
                                    pictureBox.Tag = $"White Pawn {pictureBoxName}";
                                    break;
                                case '-':
                                    pictureBox.Image = null;
                                    pictureBox.Tag = pictureBoxName;
                                    break;
                            }
                        }
                    }
                }

                pnlBoard.Refresh();
            }
            catch
            {
                // If the function encounters an error, you might want to handle it accordingly.
            }
        }

        int timesClicked = 0;
        Color oldColor_1 = Color.Empty;
        Color oldColor_2 = Color.Empty;
        Color ArrowOldColor_1 = Color.Empty;
        Color ArrowOldColor_2 = Color.Empty;

        private void PictureBox_Click(object sender, EventArgs e)
        {
            timesClicked++;
            string move = string.Empty;
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.BackColor = oldColor_2;

            if (timesClicked == 1)
            {
                oldColor_1 = pictureBox.BackColor;
                pictureBox.BackColor = Color.Gray;
                squareName = string.Empty;
            }
            else
            {
                foreach (Control c in pnlBoard.Controls)
                {
                    if (c.BackColor == Color.Gray)
                    {
                        c.BackColor = oldColor_1;
                    }
                }

                timesClicked = 0;
            }
            squareName += pictureBox.Name;

            if (squareName.Length == 4)
            {
                Send(squareName);
                squareName = string.Empty;
            }


            pnlBoard.Refresh();
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;

            oldColor_2 = pictureBox.BackColor;
            pictureBox.BackColor = Color.LightGray;
        }
        private void PictureBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                tbPrompt.Focus();
            }
        }
        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;

            if (pictureBox.BackColor == Color.LightGray)
            {
                pictureBox.BackColor = oldColor_2;
            }
        }


        private void PictureBox_Enter(object sender, EventArgs e)
        {

            PictureBox pictureBox = sender as PictureBox; // Cast sender to PictureBox

            sentence = pictureBox.Tag.ToString();
            if (tab)
            {
                speechQueue.EnqueueSpeech(sentence);
            }
            else
            {
                if (pictureBox.Tag.ToString().Length > 2)
                {
                    speechQueue.EnqueueSpeech(sentence);
                }
            }
            PictureBox_MouseEnter(sender, e);



        }
        private void PictureBox_Leave(object sender, EventArgs e)
        {

            PictureBox pictureBox = sender as PictureBox; // Cast sender to PictureBox
            PictureBox_MouseLeave(sender, e);



        }

        private void ArrowKey_Leave(PictureBox pictureBox)
        {
            if (pictureBox.BackColor == Color.LightGray)
            {
                pictureBox.BackColor = ArrowOldColor_2;
            }
        }
        private void ArrowKey_Enter(PictureBox pictureBox)
        {
            ArrowOldColor_2 = pictureBox.BackColor;
            pictureBox.BackColor = Color.LightGray;
        }
        private void ArrowKey_Confirm()
        {
            timesClicked++;
            string move = string.Empty;
            PictureBox pictureBox = CurrentPictureBox;
            pictureBox.BackColor = ArrowOldColor_2;

            if (timesClicked == 1)
            {
                oldColor_1 = pictureBox.BackColor;
                pictureBox.BackColor = Color.Gray;
                squareName = string.Empty;
            }
            else
            {
                foreach (Control c in pnlBoard.Controls)
                {
                    if (c.BackColor == Color.Gray)
                    {
                        c.BackColor = oldColor_1;
                    }
                }

                timesClicked = 0;
            }
            squareName += pictureBox.Name;

            if (squareName.Length == 4)
            {
                Send(squareName);
                squareName = string.Empty;
            }


            pnlBoard.Refresh();
        }

        private async void FocusEachPictureBoxSequentially(string s)
        {
            // Get all PictureBox controls in the panel
            var pictureBoxes = pnlBoard.Controls.OfType<PictureBox>().ToList();

            // Sort the PictureBoxes by their TabIndex property
            pictureBoxes.Sort((a, b) => a.TabIndex.CompareTo(b.TabIndex));

            // Loop through each PictureBox
            foreach (var pictureBox in pictureBoxes)
            {
                if (lookForSquare)
                {
                    if (pictureBox.Name == tbSquareName.Text)
                    {
                        speechQueue.EnqueueSpeech(pictureBox.Tag.ToString());
                        if (pictureBox.Tag.ToString().Length < 3)
                        {
                            speechQueue.EnqueueSpeech(pictureBox.Name + " is empty");
                        }
                    }
                }
                if (s == "all")
                {
                    // Set focus to the current PictureBox
                    pictureBox.Focus();
                    // Delay before moving to the next PictureBox
                    await Task.Delay(10);
                }
                if (s == "p")
                {
                    // MessageBox.Show(pictureBox.Tag.ToString());
                    if (pictureBox.Tag.ToString().Contains("Pawn"))
                    {
                        speechQueue.EnqueueSpeech(pictureBox.Tag.ToString());

                    }

                }

                if (s == "r")
                {
                    // MessageBox.Show(pictureBox.Tag.ToString());
                    if (pictureBox.Tag.ToString().Contains("Rook"))
                    {
                        speechQueue.EnqueueSpeech(pictureBox.Tag.ToString());

                    }

                }
                if (s == "n")
                {
                    // MessageBox.Show(pictureBox.Tag.ToString());
                    if (pictureBox.Tag.ToString().Contains("Knight"))
                    {
                        speechQueue.EnqueueSpeech(pictureBox.Tag.ToString());

                    }

                }
                if (s == "b")
                {
                    // MessageBox.Show(pictureBox.Tag.ToString());
                    if (pictureBox.Tag.ToString().Contains("Bishop"))
                    {
                        speechQueue.EnqueueSpeech(pictureBox.Tag.ToString());

                    }

                }
                if (s == "q")
                {
                    // MessageBox.Show(pictureBox.Tag.ToString());
                    if (pictureBox.Tag.ToString().Contains("Queen"))
                    {
                        speechQueue.EnqueueSpeech(pictureBox.Tag.ToString());

                    }

                }
                if (s == "k")
                {
                    // MessageBox.Show(pictureBox.Tag.ToString());
                    if (pictureBox.Tag.ToString().Contains("King"))
                    {
                        speechQueue.EnqueueSpeech(pictureBox.Tag.ToString());

                    }

                }



            }
            tbPrompt.Focus();
        }

        private char GetPieceFromFEN(string position)
        {
            string fen = tbGameString.Text; // Replace with your actual FEN string
            string[] fenRows = fen.Split('/');
            int rowIndex = 7 - (position[1] - '1'); // Adjust the row index calculation
            int colIndex = position[0] - 'a';

            if (rowIndex < 0 || rowIndex >= fenRows.Length || colIndex < 0 || colIndex >= fenRows[rowIndex].Length)
                return '\0';

            char piece = fenRows[rowIndex][colIndex];

            if (piece == '1')
            { // Empty square
                return '-';


            }
            else { return fenRows[rowIndex][colIndex]; }





        }

        private string GetPieceName(char piece)
        {
            switch (piece)
            {
                case 'r': return "Black Rook";
                case 'n': return "Black Knight";
                case 'b': return "Black Bishop";
                case 'q': return "Black Queen";
                case 'k': return "Black King";
                case 'p': return "Black Pawn";
                case 'R': return "White Rook";
                case 'N': return "White Knight";
                case 'B': return "White Bishop";
                case 'Q': return "White Queen";
                case 'K': return "White King";
                case 'P': return "White Pawn";
                default: return "empty ";
            }
        }


        private void StartStockFish()
        {
            engine = new Engine(this); // Create the Engine instance if not already created
            Task.Run(() => engine.StartSF(tbGameString.Text, false));
        }

        private void StopStockFish()
        {
            if (engine != null)
            {
                Task.Run(() => engine.StartSF(tbGameString.Text, true));
            }
        }

        private void btnStartEngine_Click(object sender, EventArgs e)
        {
            StartStockFish();
            tbPrompt.Focus();
            tmrEngine.Enabled = true;
        }

        public async Task sfAsync()
        {
            //  engine = new Engine(this); // Pass current instance of FrmMain
            await engine.StartSF(tbGameString.Text, false);
        }

        public async Task sf_stopAsync()
        {
            // Engine eng = new Engine(this); // Pass current instance of FrmMain
            await engine.StartSF(tbGameString.Text, true);
        }


        private void tmrEngine_Tick(object sender, EventArgs e)
        {
            speechrate = -10;
            btnReadLine_Click(sender, e);

            if (numberOfLinesRead > 3)
            {
                tmrEngine.Interval += 5000;
            }
            if (numberOfLinesRead > 5)
            {
                tmrEngine.Stop(); // enabled I learned is usually though start() and stop() has the same function, used mainly to check if the timer is started
                speechrate = 0;
                speechQueue.EnqueueSpeech("From now on you have to check the analysis by stepping move by move manually");
                numberOfLinesRead = 0;
                tmrEngine.Interval = 5000;
            }

            numberOfLinesRead++;


        }

        public static Dictionary<string, string> ParseEngineOutput(string engineOutputLine)
        {
            var data = new Dictionary<string, string>();
            var parts = engineOutputLine.Split(' ');  // split the line into parts

            // search for the score
            if (engineOutputLine.Contains("score cp"))
            {
                var scoreIndex = Array.IndexOf(parts, "score") + 2;
                data["score"] = parts[scoreIndex];
            }

            // search for the principal variation
            if (Array.IndexOf(parts, "pv") != -1)
            {
                var pvIndex = Array.IndexOf(parts, "pv");
                data["pv"] = string.Join(" ", parts.Skip(pvIndex).ToArray());
            }

            return data;
        }




        public string GetLastTwoLines(RichTextBox rtbEngineOutput)
        {
            //Not needed anymore
            if (rtbEngineOutput.Lines.Length >= 2)
            {
                string lastLine = rtbEngineOutput.Lines[rtbEngineOutput.Lines.Length - 2];//it always have newline at the end
                                                                                          //    string secondLastLine = rtbEngineOutput.Lines[rtbEngineOutput.Lines.Length - 2];
                                                                                          // there is only need to return the last line in this temporary version and maybe this is permanent
                return lastLine;
            }
            else if (rtbEngineOutput.Lines.Length == 1)
            {
                // if there is only one line, return that line
                return rtbEngineOutput.Lines[0];
            }
            else
            {
                // if there are no lines, return an empty string
                return string.Empty;
            }
        }
        public string GetPricipalVariation(RichTextBox rtbEngineOutput)
        {
            try
            {
                if (rtbEngineOutput.Lines.Length >= 3)
                {
                    // Return the third last line
                    return rtbEngineOutput.Lines[rtbEngineOutput.Lines.Length - 3];
                }
                else if (rtbEngineOutput.Lines.Length > 0)
                {
                    // If there's less than 3 lines, return the last line
                    return rtbEngineOutput.Lines[rtbEngineOutput.Lines.Length - 1];
                }
                else
                {
                    // If there are no lines, return an empty string
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                // Log the error
                label1.Text = ex.ToString();

                // If an error occurred, return an empty string
                return string.Empty;
            }
        }


        private void btnStopEngine_Click(object sender, EventArgs e)
        {
            engine.StopEngine();
            tbPrompt.Focus();
            tmrEngine.Enabled = false;
            speechQueue.EnqueueSpeech("Engine stopped");
            //  btnReadLine_Click(sender, e);

        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            string tmp_moves = string.Empty;
            Send("forward 900");
            ChessInterface ci = new ChessInterface();
            //lastResponse = tc.Read();
            //tmp_moves = ci.ExtractMovelist(rtbMainConsole.Text + lastResponse);

            //rtbPgn.Text = ci.ConvertToPGN(tmp_moves);
            tbPrompt.Focus();
        }

        private void btnReadLine_Click(object sender, EventArgs e)
        {
            string tmp = string.Empty;
            var parsedData = ParseEngineOutput(rtbEngineOutPut.Lines[rtbEngineOutPut.Lines.Length - 2]);

            // Check if the keys "score" and "pv" exist in the dictionary before accessing them
            if (parsedData.ContainsKey("score") && parsedData.ContainsKey("pv"))
            {
                string score = ConvertDigitsToWords(parsedData["score"]);
                string pv = parsedData["pv"];

                if (pv.Length > 20)
                {
                    tmp = pv.Substring(0, 20);
                }
                else
                {
                    tmp = pv;
                }

                // Use the variables `score` and `pv` as you need

                speechQueue.EnqueueSpeech("Score" + score + "Line" + tmp);

            }
            else
            {
                speechQueue.EnqueueSpeech("The score or PV data is missing.");
            }



            tbPrompt.Focus();

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (tmrRead.Enabled)
            {
                tmrRead.Enabled = false;
                btnRead.BackColor = Color.Red;

            }
            else
            {
                tmrRead.Enabled = true;
                btnRead.BackColor = Color.Green;
            }
            tbPrompt.Focus();
        }
        private void readPush()
        {

            bool isHandled = false;
            string tmp = string.Empty;
            lastResponse = tc.Read();
            allHistory += lastResponse;
            rtbLog.Text += lastResponse;
            if (lastResponse.Contains("<12>"))
            {
                //tmpLastResponse = lastResponse;
                ObserveGame();

                //btnMoves_Click(this, new EventArgs());
                //button2_Click(this, new EventArgs());

            }
            if (lastResponse.Length > 2)
            {


                string[] patterns = { "{Game ", "kibitz", "tells", "says", "Movelist" };
                foreach (string pattern in patterns)
                {
                    string tmp2 = string.Empty;
                    if (lastResponse.Contains(pattern))
                    {
                        switch (pattern)
                        {
                            case "{Game ":
                                tmp2 = lastResponse.Replace("fics%", "");
                                rtbGames.Text += tmp;
                                if (tmp2.Contains(gameToLoookFor))
                                {
                                    rtbMyGame.Text = tmp;
                                }
                                isHandled = true;
                                break;

                            case "kibitz":
                            case "tells":
                            case "says":
                                sentence = lastResponse.Replace("fics%", "");
                                //speechQueue.EnqueueSpeech(sentence);
                                tmp = lastResponse.Replace("fics%", "");
                                rtbTells.Text += tmp;
                                //rtbMainConsole.Text += lastResponse;
                                break;

                            case "Movelist":
                                isHandled = true;
                                lastResponse = lastResponse.Replace("fics%", "");
                                lastResponse = lastResponse.Replace("/", "");
                                lastResponse = lastResponse.Replace("\\", "");
                                rtbMovesListRaw.Text += lastResponse;
                                //speechQueue.EnqueueSpeech(lastResponse);
                                break;
                        }
                        if (isHandled)
                            break;
                    }
                }
                if (!isHandled)
                {
                    if (lastResponse.Contains("<12>"))
                    {
                        lastResponse = lastResponse.Replace("fics%", "");
                        lastResponse = lastResponse.Replace("/", "");
                        lastResponse = lastResponse.Replace("\\", "");
                        rtbLogGamestring.Text += tbLastResponse;
                    }
                    else
                    {
                        lastResponse = lastResponse.Replace("fics%", "");
                        lastResponse = lastResponse.Replace("/", "");
                        lastResponse = lastResponse.Replace("\\", "");
                        rtbMainConsole.Text += lastResponse;
                        speechQueue.EnqueueSpeech(lastResponse);


                    }


                }

            }


        }
        private void AppendLog(string message)
        {
            if (rtbLogGamestring.InvokeRequired)
            {
                rtbLogGamestring.Invoke(new Action<string>(AppendLog), new object[] { message });
            }
            else
            {
                rtbLogGamestring.AppendText(message + "\r\n");
            }
        }

        private void tmrRead_Tick(object sender, EventArgs e)
        {
            readPush();



        }

        private void btnMoves_Click(object sender, EventArgs e)
        {
            Send("moves");
            noMovesReading = false;
            ChessInterface ci = new ChessInterface();
            //rtbMovesListRaw.Text = lastResponse.Replace("fics%", "");
            string data = lastResponse;
            var lines = data.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (var line in lines)
            {
                if (line.Trim().StartsWith("1."))
                {
                    var cells = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    dataGridView2.Rows.Add(cells);
                    MessageBox.Show(cells.ToString());
                }
            }
            dataGridView2.Refresh();

            tbPrompt.Focus();
        }




        private void button2_Click(object sender, EventArgs e)
        {
            ChessInterface ci = new ChessInterface();
            FrmMain frmMain = new FrmMain();
            // ...
            CreatePGN();
            tbPrompt.Focus();

        }
        public string CreatePGN()
        {
            string[] lines = rtbMovesListRaw.Lines;
            StringBuilder pgnBuilder = new StringBuilder();

            // Find move section start index
            int moveSectionStartIndex = Array.FindIndex(lines, line => line.StartsWith("----  ----------------   ----------------"));
            if (moveSectionStartIndex == -1)
            {
                return "Move section not found.";
            }

            // Retrieve player names from the line above move section start
            string playerLine = lines[moveSectionStartIndex - 2];
            if (playerLine.Length < 42)
            {
                return "Unable to find player names.";
            }

            string player1 = playerLine.Substring(6, 16).Trim();
            string player2 = playerLine.Substring(25, 16).Trim();

            // Extract result from the line below move section end
            string resultLine = lines[lines.Count() - 1];
            string result = "NOT AVAILABLE YET";

            // Add PGN header
            pgnBuilder.AppendLine("[Event \"Rated standard match\"]");
            pgnBuilder.AppendLine($"[White \"{player1}\"]");
            pgnBuilder.AppendLine($"[Black \"{player2}\"]");
            pgnBuilder.AppendLine($"[Result \"{result}\"]");

            // Extract moves from move section
            pgnBuilder.AppendLine();
            pgnBuilder.AppendLine("[Moves]");

            StringBuilder movesBuilder = new StringBuilder();

            for (int i = moveSectionStartIndex + 2; i < lines.Length; i++)
            {
                string line = lines[i].Trim();

                if (string.IsNullOrEmpty(line))
                    continue;

                string[] moveParts = line.Split(new string[] { ".", "  " }, StringSplitOptions.RemoveEmptyEntries);
                if (moveParts.Length >= 5)
                {
                    string moveNumber = moveParts[0].Trim();
                    string whiteMove = moveParts[1].Trim();
                    string blackMove = moveParts[3].Trim();

                    movesBuilder.Append($"{moveNumber}. {whiteMove} {blackMove} ");
                }
            }

            pgnBuilder.Append(movesBuilder.ToString().Trim());
            rtbPgn.Text = pgnBuilder.ToString().Trim();
            rtbPgn.Refresh();
            return "OK";
        }
        private void tmrSmoothUpdate_Tick(object sender, EventArgs e)
        {

            //rtbMainConsole.SelectionStart = rtbMainConsole.Text.Length;
            //rtbMainConsole.ScrollToCaret();
        }

        private void rtbMainConsole_TextChanged(object sender, EventArgs e)
        {

            rtbMainConsole.SelectionStart = rtbMainConsole.Text.Length;
            rtbMainConsole.ScrollToCaret();
        }
        private string interpetEngineLine(string s)
        {
            try
            {
                string cpKey = "cp    ";
                string nodesKey = " nodes";

                int startIndex = s.IndexOf(cpKey) + cpKey.Length;
                int endIndex = s.IndexOf(nodesKey);
                string centipawn = s.Substring(startIndex, endIndex - startIndex).Trim();


                //string line = "info depth 15 seldepth 26 multipv 1 score cp 363 nodes 461804 nps 1021690 tbhits 0 time 452 pv a1a8 e8f7 a8h8 f7f6 h8e8 g7g1 e1e2 g1g3 e8e3 g3g1 e2d3 g1f1 d3c4 f6g7 d2d5 f1f7 c4b5 g7f8 b5c5";
                string pvKey = " pv ";
                string principalVariation = string.Empty;
                // int startIndex2 = s.IndexOf(pvKey) + pvKey.Length;
                int startIndex2 = s.IndexOf(pvKey);

                //int startIndex2 = s.IndexOf(pvKey);

                if (startIndex2 != -1) // if "pv " is found in the string
                {
                    //MessageBox.Show($"pvKey found at index {startIndex2} in string: {s}");
                    startIndex2 += pvKey.Length;  // Move the start index to the end of "pv "
                    principalVariation = s.Substring(startIndex2).Trim();

                    // principalVariation now holds "a1a8 e8f7 a8h8 f7f6 h8e8 g7g1 e1e2 g1g3 e8e3 g3g1 e2d3 g1f1 d3c4 f6g7 d2d5 f1f7 c4b5 g7f8 b5c5"
                    // MessageBox.Show(principalVariation);
                }
                else
                {
                    //  MessageBox.Show($"pvKey not found in string: {s}");
                }


                string moves = principalVariation;
                string[] movesArray = moves.Split(' ');

                StringBuilder formattedMoves = new StringBuilder();

                for (int i = 0; i < movesArray.Length; i++)
                {
                    string move = movesArray[i];

                    if (move.Length == 4)
                    {
                        formattedMoves.Append($"{move.Substring(0, 2)} to {move.Substring(2, 2)} ");
                    }
                    else
                    {
                        // handle the case when the move isn't 4 characters
                        // you might need to adjust this based on your specific requirements
                        formattedMoves.Append(move + " ");
                    }
                }

                string result = formattedMoves.ToString().Trim(); // final result
                result = "Evaluation in centi pawn " + centipawn + result;
                return result;
            }
            catch (Exception ex)
            {
                // Catch the exception and print it to the Console.
                //Console.WriteLine(ex.ToString());
                return null;

            }
        }



        private void WriteLog()
        {
            try
            {
                string fileName = "log.txt";
                string filePath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, fileName);
                string richTextBoxText = richTextBox1.Text; // richTextBox1 is your RichTextBox

                // Append the text to the file
                System.IO.File.AppendAllText(filePath, richTextBoxText);
            }
            catch (Exception ex)
            {
                // Handle or display the error
                //Console.WriteLine(ex.Message);
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            CreatePGN();
            tbPrompt.Focus();
        }

        private void tbLastResponse_TextChanged(object sender, EventArgs e)
        {
            if (lastResponse.Contains("<12>"))
            {
                ObserveGame();
                //Removed the sending of the "moves command, should be done only once per observed game" /Lars
            }
        }

        private void rtbMovesListRaw_TextChanged(object sender, EventArgs e)
        {
            rtbMovesListRaw.SelectionStart = rtbMovesListRaw.Text.Length;
            rtbMovesListRaw.ScrollToCaret();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Send("back");
            tbPrompt.Focus();

        }





        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                speechQueue.CancelSpeech();
            }
            if (e.KeyCode == Keys.F11)
            {
                tbPrompt.Clear();
            }
            if (e.Control)
            {
                speechQueue.CancelSpeech();
                //MessageBox.Show("CTRL");
            }
            if (e.KeyCode == Keys.Escape)
            {
                //MessageBox.Show("ESC");
                tbPrompt.Clear();
            }


            if (e.KeyCode == Keys.F1)
            {
                rtbHelp.Visible = true; rtbHelp.Focus();
                if (rtbHelp.Lines.Length > 0)
                {
                    string firstLine = rtbHelp.Lines[0];
                    int start = rtbHelp.GetFirstCharIndexFromLine(0);  // starting index of the first line
                    int length = firstLine.Length;  // length of the first line

                    rtbHelp.Select(start, length);  // select the first line
                }

            }
            else if (e.KeyCode == Keys.F2)
            {
                if (amIPlaying == "-1" || amIPlaying == "1")
                {
                    btnStartEngine.Enabled = false;
                    speechQueue.EnqueueSpeech("You cannot start the engine while playing, when playing any outside assitance whatsoever is strictly forbidden");
                }
                else
                {
                    btnStartEngine_Click(this, EventArgs.Empty);
                }


            }
            else if (e.KeyCode == Keys.F3)
            {
                tbPrompt.Focus();
            }
            else if (e.KeyCode == Keys.F4)
            {
                tab = true;
                pnlBoard.Focus();
            }

            else if (e.KeyCode == Keys.F6)
            {
                /*  Speech speech = new Speech((int)nudSpeachrate.Value, 50);
                  sentence = GetLastTwoLines(rtbEngineOutPut);
                  if (sentence.Any(char.IsDigit))
                  {
                      speechQueue.EnqueueSpeech(ConvertDigitsToWords(sentence));
                  }
                  else
                  {
                      speechQueue.EnqueueSpeech(sentence);
                  } */

                tbPrompt.Focus();
            }

            else if (e.KeyCode == Keys.F5)
            {
                tab = false;
                FocusEachPictureBoxSequentially("all");
            }
            if (e.KeyCode == Keys.Space)
            {
                ArrowKey_Confirm();
            }

        }
        //private void SelectablePictureBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
        //    {
        //        SelectablePictureBox selectedPictureBox = (SelectablePictureBox)sender;

        //        int selectedIndex = selectedPictureBox.TabIndex;
        //        int row = (selectedIndex - 1) / 8;
        //        int column = (selectedIndex - 1) % 8;
        //        Text = row.ToString() + column.ToString();
        //        if (e.KeyCode == Keys.Left)
        //        {
        //            if (column > 0)
        //            {
        //                SelectablePictureBox previousPictureBox = pnlBoard.Controls.OfType<SelectablePictureBox>().FirstOrDefault(p => p.TabIndex == selectedIndex - 1);
        //                previousPictureBox?.Focus();
        //            }
        //        }
        //        else if (e.KeyCode == Keys.Right)
        //        {
        //            if (column < 7)
        //            {
        //                SelectablePictureBox nextPictureBox = pnlBoard.Controls.OfType<SelectablePictureBox>().FirstOrDefault(p => p.TabIndex == selectedIndex + 1);
        //                nextPictureBox?.Focus();
        //            }
        //        }
        //        else if (e.KeyCode == Keys.Up)
        //        {
        //            if (row > 0)
        //            {
        //                SelectablePictureBox abovePictureBox = pnlBoard.Controls.OfType<SelectablePictureBox>().FirstOrDefault(p => p.TabIndex == selectedIndex - 8);
        //                abovePictureBox?.Focus();
        //            }
        //        }
        //        else if (e.KeyCode == Keys.Down)
        //        {
        //            if (row < 7)
        //            {
        //                SelectablePictureBox belowPictureBox = pnlBoard.Controls.OfType<SelectablePictureBox>().FirstOrDefault(p => p.TabIndex == selectedIndex + 8);
        //                belowPictureBox?.Focus();
        //            }
        //        }

        //        // Prevent further processing of the arrow key by the picture box
        //        e.IsInputKey = true;
        //    }
        //}


        private char GetCharacterAtCursor(RichTextBox richTextBox)
        {
            int cursorPosition = richTextBox.SelectionStart;

            if (cursorPosition >= 0 && cursorPosition < richTextBox.TextLength)
            {
                return richTextBox.Text[cursorPosition];
            }

            return '\0'; // Return null character if cursor position is invalid
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                Connect();
            }
        }

        private void tbUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                Speech speech = new Speech((int)nudSpeachrate.Value, 100);
                sentence = "Please type your password and press enter";
                speechQueue.EnqueueSpeech(sentence);

                tbPassword.Focus();
            }

        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            tbUser.Focus();  // Now the call to Focus() will work as expected
            tbUser.SelectAll();
            // Speech speech = new Speech((int)nudSpeachrate.Value);
            sentence = "Please type your username and press enter";
            speechQueue.EnqueueSpeech(sentence);

        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            int number;
            bool success;

            if (sideToMove == "W")
            {
                string numberStr = lblWhitesRemainingTime.Text;

                success = int.TryParse(numberStr, out number);

                if (success)
                {
                    number--;
                    lblWhitesRemainingTime.Text = number.ToString();
                    lblWhitesRemainingTimeFormated.Text = FormatTime(number);
                }
                else
                {
                    // The string could not be converted to an integer
                }
            }
            else
            {
                string numberStr = lblBlacksRemainingTime.Text;

                success = int.TryParse(numberStr, out number);

                if (success)
                {
                    number--;
                    lblBlacksRemainingTime.Text = number.ToString();
                    lblBlacksRemainingTimeFormated.Text = FormatTime(number);
                }
                else
                {
                    // The string could not be converted to an integer
                }
            }
        }


        private void btnMovesDebug_Click(object sender, EventArgs e)
        {
            if (!richTextBox1.Visible)
            {
                richTextBox1.Visible = true;
                richTextBox1.BringToFront();
                richTextBox1.Refresh();


            }
            else
            {
                richTextBox1.Visible = false;
            }
            tbPrompt.Focus();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            Send("Forward");
            tbPrompt.Focus();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Send("Back 100");
            tbPrompt.Focus();

        }

        private void pnlBoard_Enter(object sender, EventArgs e)
        {
            // Find the first PictureBox in the panel
            //PictureBox firstPictureBox = pnlBoard.Controls.OfType<PictureBox>().FirstOrDefault();

            //// If a PictureBox was found, set focus to it
            //if (firstPictureBox != null)
            //{
            //    firstPictureBox.Focus();
            //}
        }

        private void tbUser_Enter(object sender, EventArgs e)
        {

        }

        private void FrmMain_MouseEnter(object sender, EventArgs e)
        {

        }

        private void btnGamesConsole_Click(object sender, EventArgs e)
        {
            if (!rtbGames.Visible)
            {
                rtbGames.Visible = true;
                rtbGames.BringToFront();
                rtbGames.Refresh();


            }
            else
            {
                rtbGames.Visible = false;
            }
            tbPrompt.Focus();
        }



        private void rtbGames_TextChanged(object sender, EventArgs e)
        {
            rtbGames.SelectionStart = rtbGames.Text.Length;
            rtbGames.ScrollToCaret();
        }

        private void rtbTells_TextChanged(object sender, EventArgs e)
        {
            rtbTells.SelectionStart = rtbGames.Text.Length;
            rtbTells.ScrollToCaret();
        }





        private void btnTellsConsole_Click(object sender, EventArgs e)
        {
            if (!rtbTells.Visible)
            {
                rtbTells.Visible = true;
                rtbTells.BringToFront();
                rtbTells.Refresh();


            }
            else
            {
                rtbTells.Visible = false;
            }
            tbPrompt.Focus();
        }



        private void richTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            RichTextBox richTextBox = sender as RichTextBox; // Cast sender to RichTextBox

            if (richTextBox != null) // Safety check
            {
                GetRowAndPosition(richTextBox2);
            }
        }
        private void richTextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            RichTextBox richTextBox = sender as RichTextBox; // Cast sender to RichTextBox

            if (richTextBox != null) // Safety check
            {
                GetRowAndPosition(richTextBox2);
            }
        }
        private void GetRowAndPosition(RichTextBox richTextBox)
        {
            Point cursorLocation = richTextBox.PointToClient(Cursor.Position);
            int cursorIndex = richTextBox.GetCharIndexFromPosition(cursorLocation);
            int row = richTextBox.GetLineFromCharIndex(cursorIndex);
            int position = cursorIndex - richTextBox.GetFirstCharIndexFromLine(row);
            char character = richTextBox.Text[cursorIndex];

            // Use the extracted values as needed
            label1.Text = $"Row: {row}, Position: {position}, Character: {character}";
        }









        private void richTextBox2_SelectionChanged(object sender, EventArgs e, string cursorPosition)
        {
            RichTextBox richTextBox = sender as RichTextBox; // Cast sender to RichTextBox

            if (richTextBox != null) // Safety check
            {
                // MessageBox.Show(GetCharacterAtCursor(richTextBox).ToString() + " at position " + cursorPosition);
            }
        }

        private void richTextBox2_KeyDown(object sender, KeyEventArgs e, string cursorPosition)
        {
            if (richTextBox2 != null) // Safety check
            {
                // MessageBox.Show(GetCharacterAtCursor(richTextBox2).ToString() + " at position " + cursorPosition);
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string fileName = "log.txt";
                string filePath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, fileName);
                //  string richTextBoxText = richTextBox1.Text; // richTextBox1 is your RichTextBox

                // Append the text to the file
                System.IO.File.AppendAllText(filePath, allHistory);
            }
            catch (Exception ex)
            {
                // Handle or display the error
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDebugPieces_Click(object sender, EventArgs e)
        {
            rtbLogGamestring.Visible = true;
            rtbLogGamestring.BringToFront();
            rtbLogGamestring.Refresh();
        }
        private bool dataGridViewVisible = true;
        private void btnParseEngineLine_Click(object sender, EventArgs e)
        {
            // Initialize a new DataGridView
            dataGridView1 = new DataGridView();
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            dataGridView1.CellEnter += new DataGridViewCellEventHandler(dataGridView1_CellEnter);
            dataGridView1.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.Font = new Font("Consolas", 12, FontStyle.Regular);
            // Define the columns
            dataGridView1.Columns.Add("Cp", "Cp");
            dataGridView1.Columns.Add("PvMoves", "Pv Moves");
            dataGridView1.Rows.Add();
            try
            {
                foreach (string line in rtbEngineOutPut.Lines)
                {
                    var values = ParseAndAssignLinesFromRichTextBox(line);
                    dataGridView1.Rows.Add(values);
                    /*if (line.Contains("info depth"))
                    {
                        values = ParseAndAssignLinesFromRichTextBox(line);

                        // Add a new row in the DataGridView using the array of values
                        dataGridView1.Rows.Add(values);
                    }*/
                }
            }
            catch (Exception ex)
            {
                // Handle the exception or do nothing
            }


            // Add the DataGridView to the form's controls
            this.Controls.Add(dataGridView1);

            dataGridView1.Dock = DockStyle.Top;
            dataGridView1.Refresh();
            dataGridView1.BringToFront();
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[0];
            Button closeButton = new Button();
            closeButton.Text = "Close Grid";
            closeButton.Dock = DockStyle.Bottom; // Adjust this to fit your layout
            closeButton.Click += new EventHandler(closeButton_Click);
            this.Controls.Add(closeButton);

        }


        private DataGridView dataGridView1;
        // Then, define the event handler method

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // ensure valid row and column indices

                var cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                // Check if cellValue is not null and not empty
                if (cellValue == null || string.IsNullOrEmpty(cellValue.ToString())) return;

                int columnIndex = e.ColumnIndex;
                string output = string.Empty;

                // Split the input string into an array of strings
                string[] moves = cellValue.ToString().Split(' ');

                // Process each move
                if (columnIndex == 1)
                {
                    for (int i = 0; i < moves.Length; i++)
                    {
                        // Ensure that moves[i] has at least 4 characters before proceeding
                        if (moves[i].Length < 4) continue;

                        // Split the move into two parts and join them with " to "
                        string[] parts = new string[2] { moves[i].Substring(0, 2), moves[i].Substring(2, 2) };
                        moves[i] = string.Join(" to ", parts);
                        output = string.Join(" ", moves);
                    }
                }
                else
                {
                    output = ConvertDigitsToWords(string.Join(" ", moves));
                }


                speechQueue.EnqueueSpeech(output);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                //Debug.WriteLine(ex.ToString());
            }

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            string output = string.Empty;
            // Perform actions here...
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                var cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                speechQueue.EnqueueSpeech($"{cellValue}");
                // Split the input string into an array of strings
                string[] moves = cellValue.ToString().Split(' ');
                // Process each move
                if (columnIndex == 1)
                {
                    for (int i = 0; i < moves.Length; i++)
                    {
                        // Split the move into two parts and join them with " to "
                        string[] parts = new string[2] { moves[i].Substring(0, 2), moves[i].Substring(2, 2) };
                        moves[i] = string.Join(" to ", parts);
                        output = string.Join(" ", moves);
                    }
                }
                else
                {
                    output = ConvertDigitsToWords(string.Join(" ", moves));
                }
                // Join the processed moves back into a string
                speechQueue.EnqueueSpeech(output);
            }
        }

        void closeButton_Click(object sender, EventArgs e)
        {
            // Check if DataGridView is currently displayed
            if (this.Controls.Contains(dataGridView1))
            {
                this.Controls.Remove(dataGridView1);

            }
        }
        private void rtbLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*
             * We must scan after available voices if we want to use other tan default
             * so this will not be impllemented

                // Create an instance of SpeechSynthesizer
                SpeechSynthesizer synthesizer = new SpeechSynthesizer();

                // Get the available voices
                IEnumerable<InstalledVoice> voices = synthesizer.GetInstalledVoices();

                // Switch to a specific voice
                if (voices.Any(v => v.VoiceInfo.Name == "Microsoft David Desktop"))
                {
                    synthesizer.SelectVoice("Microsoft David Desktop");
                }

                // Speak a sentence using the selected voice
                synthesizer.Speak("This is the voice of Microsoft David Desktop");

                // Switch to another voice
                if (voices.Any(v => v.VoiceInfo.Name == "Microsoft Zira Desktop"))
                {
                    synthesizer.SelectVoice("Microsoft Zira Desktop");
                }

                // Speak another sentence using the new voice
                synthesizer.Speak("This is the voice of Microsoft Zira Desktop"); */
            //  UpdateReversedBoard(board);


        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            pnlServer.Width = this.Width - 550;
            rtbMainConsole.Width = Convert.ToInt32(pnlServer.Width * 0.6);
            dataGridView2.Width = Convert.ToInt32(pnlServer.Width * 0.4);
            dataGridView2.Left = rtbMainConsole.Width;
            rtbGameMovesVerbose.Width = dataGridView2.Width;
            rtbGameMovesVerbose.Left = dataGridView2.Left;
            pnlEngineAndCommunication.Width = pnlServer.Width;
        }

        private void btnShowDebugPanel_Click(object sender, EventArgs e)
        {
            if (pnlDebug.Visible)
            {
                pnlDebug.Visible = false;
            }
            else
            {
                pnlDebug.Visible = true;
                pnlDebug.BringToFront();
            }
        }

        private void btnTellsAndMoves_Click(object sender, EventArgs e)
        {


        }

        private void cbReverseBoard_Click(object sender, EventArgs e)
        {
            if (cbReverseBoard.Checked)
            {
                UpdateBoard(board);
            }
            else
            {
                UpdateReversedBoard(board);
            }
        }

        private void rtbEngineOutPut_TextChanged(object sender, EventArgs e)
        {
            rtbEngineOutPut.SelectionStart = rtbEngineOutPut.Text.Length;
            rtbEngineOutPut.ScrollToCaret();
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            if (cb.Checked)
            {
                speechQueue.UnmuteSpeech();
            }
            else
            {
                speechQueue.MuteSpeech();
            }
        }

        private void btnCloseGrid_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(dataGridView1);
        }

        private void rtbMainConsole_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void rtbMainConsole_SelectionChanged(object sender, EventArgs e)
        {
            int selectedLineIndex = rtbMainConsole.GetLineFromCharIndex(rtbMainConsole.SelectionStart);

            // Lines is a zero-based array, so we need to ensure the index is within its bounds
            if (selectedLineIndex >= 0 && selectedLineIndex < rtbMainConsole.Lines.Length)
            {
                string selectedLineText = rtbMainConsole.Lines[selectedLineIndex];

                if (!string.IsNullOrEmpty(selectedLineText)) // Check if the line contains any text
                {
                    speechQueue.EnqueueSpeech(selectedLineText);
                }
            }
        }

        private void rtbMainConsole_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void rtbMainConsole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                tbPrompt.Focus();
            }
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.BringToFront();
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                dataGridView2.BringToFront();
                if (dataGridView2.CurrentCell.Value != null)
                {
                    string value = dataGridView2.CurrentCell.Value.ToString();
                    speechQueue.EnqueueSpeech(value);
                }
                else
                {
                    // Handle the case when the cell is empty. For example, you can display a message to the user.
                    MessageBox.Show("The selected cell is empty.");
                }
            }
            catch (Exception ex)
            {
                // Log the error or display a message box with the error.
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }


        private void rtbEngineOutPut_Click(object sender, EventArgs e)
        {
            rtbEngineOutPut.BringToFront();
        }

        private void rtbMainConsole_Click(object sender, EventArgs e)
        {
            rtbMainConsole.BringToFront();
        }

        private void rtbPgn_Click(object sender, EventArgs e)
        {
            rtbPgn.BringToFront();
        }

        private void rtbGames_Click(object sender, EventArgs e)
        {
            rtbGames.BringToFront();
        }

        private void rtbTells_Click(object sender, EventArgs e)
        {
            rtbTells.BringToFront();
        }

        private void pnlDebug_Click(object sender, EventArgs e)
        {
            pnlDebug.BringToFront();
        }

        private void rtbMyGame_TextChanged(object sender, EventArgs e)
        {
            speechQueue.EnqueueSpeech(rtbMyGame.Text);
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            speechQueue.EnqueueSpeech(dataGridView2.CurrentCell.Value.ToString());
        }

        private void tbSquareName_TextChanged(object sender, EventArgs e)
        {
            FocusEachPictureBoxSequentially(tbSquareName.Text);

        }

        private void FrmMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                //altPressed = false;
            }

        }

        private void FrmMain_Load_1(object sender, EventArgs e)
        {

        }

        private void FrmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if ((Form.ModifierKeys & Keys.Alt) == Keys.Alt)
			{
                tbPrompt.Focus();
				// The Alt key is down. Now you can process other keys
				if (char.IsLetter(e.KeyChar))
				{
                    // A letter key was pressed while Alt was down. 
                    // Do something with the letter
                    altPressed = true;
					tbPrompt.Text += e.KeyChar;
				}
			}*/
        }

        private void rtbHelp_SelectionChanged(object sender, EventArgs e)
        {

            speechQueue.EnqueueSpeech(rtbHelp.SelectedText);


        }

        private void rtbHelp_KeyDown(object sender, KeyEventArgs e)
        {
            int startIndex = rtbHelp.SelectionStart;
            int lineIndex = rtbHelp.GetLineFromCharIndex(startIndex);

            string selectedLine = rtbHelp.Lines[lineIndex];
            if (rtbHelp.Lines.Length > 0)
            {
                string firstLine = rtbHelp.Lines[lineIndex];
                int start = rtbHelp.GetFirstCharIndexFromLine(lineIndex);  // starting index of the first line
                int length = firstLine.Length;  // length of the first line

                rtbHelp.Select(start, length);  // select the first line
            }

        }

        private void rtbHelp_MouseClick(object sender, MouseEventArgs e)
        {
            rtbHelp.Visible = false;
        }

        private void tbPrompt_KeyUp(object sender, KeyEventArgs e)
        {
            // If the left or right arrow key was pressed
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                // Check if the TextBox isn't empty and the cursor is at a valid position
                if (!string.IsNullOrEmpty(tbPrompt.Text) && tbPrompt.SelectionStart < tbPrompt.Text.Length && tbPrompt.SelectionStart >= 0)
                {
                    // Get the character at the cursor position
                    char character = tbPrompt.Text[tbPrompt.SelectionStart];

                    // Use your text-to-speech function to read the character
                    speechQueue.EnqueueSpeech(character.ToString());
                }
            }
        }

        private void pnlBoard_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true; // This tells the system that we're handling this key press.
                tbPrompt.Focus();
            }
        }

        private void rtbHelp_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true; // This tells the system that we're handling this key press.
                tbPrompt.Focus();
            }
        }

        private void rtbGameMovesVerbose_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true; // This tells the system that we're handling this key press.
                tbPrompt.Focus();
            }
        }

        private void dataGridView2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true; // This tells the system that we're handling this key press.
                tbPrompt.Focus();
            }
        }

        private void FrmMain_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            /*if (e.Alt)
			{
				e.IsInputKey = true;
				altPressed = true;
                textBox1.BackColor = Color.Red;

			}*/

        }

        private void tbPrompt_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.Alt)
            {
                e.IsInputKey = true;
                altPressed = true;
                arrowkeyControllBox.BackColor = Color.Red;

            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void Keypressed(Object o, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Down)
            {
                Text = "pressed";
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            arrowkeyControllBox.Focus();


            //string row = rtbMainConsole.T
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void arrowkeyControllBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                ArrowKey_Leave(CurrentPictureBox); //deselects the current square
                // update the current position after arrow key input
                switch (e.KeyCode)
                {

                    case (Keys.Down):
                        if (currentSquare[1] > 1)
                            currentSquare[1]--;
                        else speechQueue.EnqueueSpeech(CurrentSquareName);
                        break;
                    case (Keys.Up):
                        if (currentSquare[1] < 8)
                            currentSquare[1]++;
                        else speechQueue.EnqueueSpeech(CurrentSquareName);
                        break;
                    case (Keys.Left):
                        if (currentSquare[0] > 0)
                            currentSquare[0]--;
                        else speechQueue.EnqueueSpeech(CurrentSquareName);
                        break;
                    case (Keys.Right):
                        if (currentSquare[0] < 7)
                            currentSquare[0]++;
                        else speechQueue.EnqueueSpeech(CurrentSquareName);
                        break;
                }
                //updates the board to highlight the current hovered sqaure
                pnlBoard.Refresh();
                ArrowKey_Enter(CurrentPictureBox);
                Text = ((char)('a' + currentSquare[0])) + currentSquare[1].ToString();
                arrowkeyControllBox.Focus();
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvGames_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {

        }

        private void dgvGames_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)sender).Rows.Count > 1)
            {


                speechQueue.CancelSpeech();
                var currentCell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
                string cellData = currentCell.Value.ToString();
                if (cellData == "++++")
                    cellData = "no rank";
                if (((DataGridView)sender).Columns[e.ColumnIndex].HeaderText == "Type")
                {
                    if (cellData.Contains("sr"))
                        cellData = "standard ranked " + cellData.Replace("sr", "");
                    else if (cellData.Contains("br"))
                        cellData = "bullet ranked " + cellData.Replace("br", "");
                    else if (cellData.Contains("su"))
                        cellData = "standard unranked " + cellData.Replace("su", "");
                    else if (cellData.Contains("bu"))
                        cellData = "bullet unranked " + cellData.Replace("bu", "");
                }
                speechQueue.EnqueueSpeech(((DataGridView)sender).Columns[e.ColumnIndex].HeaderText + " " + cellData);
                Console.WriteLine(((DataGridView)sender).Columns[e.ColumnIndex].HeaderText + " " + cellData);
            }
        }

        private void dgvGames_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(sender);
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {

            }
        }

        private void dgvGames_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }
    }
}


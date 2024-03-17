using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Move2VoiceBeta
{
    public class Engine
    {
        private Process startSF;
        private FrmMain mainForm;
        private RichTextBox txtOutput;

        public Engine(FrmMain form1)
        {
            mainForm = form1;
            txtOutput = mainForm.rtbEngineOutPut;
        }

        public async Task StartSF(string fen, bool stop)
        {
            string command = "go movetime 100000";

            startSF = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "stockfish",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    CreateNoWindow = true
                }
            };

            startSF.Start();

            startSF.StandardInput.WriteLine("ucinewgame");
            startSF.StandardInput.WriteLine("setoption name UCI_AnalyseMode value true");
            startSF.StandardInput.WriteLine("position fen " + fen);
            startSF.StandardInput.WriteLine(command);
            await Task.Delay(10);

            string line;
            while ((line = startSF.StandardOutput.ReadLine()) != null)
            {
                List<string> parsedLines = ParseEngineOutput(line);

                // Update the output on the main form
                foreach (string parsedLine in parsedLines)
                {
                    UpdateOutput(parsedLine);
                }


            }
        }

        public void StopEngine()
        {
            if (startSF != null && !startSF.HasExited)
            {
                startSF.StandardInput.WriteLine("stop");
                UpdateOutput("STOPPED");
            }
        }


        private void UpdateOutput(string output)
        {
            if (txtOutput.InvokeRequired)
            {
                txtOutput.Invoke(new Action<string>(UpdateOutput), output);
            }
            else
            {
                txtOutput.AppendText(output + Environment.NewLine);
            }
        }
        public List<string> ParseEngineOutput(string output)
        {
            List<string> relevantLines = new List<string>();

            string[] lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                if (line.StartsWith("info") && line.Contains("depth") && line.Contains("multipv"))
                {
                    string[] tokens = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string searchDepth = GetTokenValue(tokens, "depth");
                    string multiPV = GetTokenValue(tokens, "multipv");
                    string moves = GetMovesFromLine(line);

                    relevantLines.Add($"Search Depth: {searchDepth}, MultiPV: {multiPV}, Moves: {moves}");
                }
            }

            return relevantLines;
        }

        private string GetTokenValue(string[] tokens, string token)
        {
            for (int i = 0; i < tokens.Length - 1; i++)
            {
                if (tokens[i] == token)
                {
                    return tokens[i + 1];
                }
            }
            return string.Empty;
        }

        private string GetMovesFromLine(string line)
        {
            int startIndex = line.IndexOf("pv ") + 3;
            return line.Substring(startIndex);
        }
    }
}


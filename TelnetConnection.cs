using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Move2VoiceBeta
{
    // Telnet commands. A lot of error handling might be needed.
    enum Verbs
    {
        WILL = 251,
        WONT = 252,
        DO = 253,
        DONT = 254,
        IAC = 255
    }

    // Telnet options
    enum Options
    {
        SGA = 3
    }

    class TelnetConnection
    {
        TcpClient tcpSocket;
        int TimeOutMs = 100;

        // Constructor that establishes a TCP connection to the provided hostname and port
        public TelnetConnection(string Hostname, int Port)
        {
            try
            {
                tcpSocket = new TcpClient(Hostname, Port);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                MessageBox.Show($"An error occurred while establishing the TCP connection: {ex.Message}");
                throw; // Rethrow the exception to propagate it further
            }
        }
        public void Close()
        {
            try
            {
                if (tcpSocket != null)
                {
                    tcpSocket.Close();
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                MessageBox.Show($"An error occurred while closing the connection: {ex.Message}");
                throw; // Rethrow the exception to propagate it further
            }
        }
        // Method to perform login to the telnet server
        public string Login(string Username, string Password, int LoginTimeOutMs)
        {
            int oldTimeOutMs = TimeOutMs;
            TimeOutMs = LoginTimeOutMs;
            string s = Read();
            WriteLine(Username);
            s += Read();
            WriteLine(Password);
            s += Read();
            TimeOutMs = oldTimeOutMs;
            return s;
        }

        // Method to write a line to the telnet server
        public void WriteLine(string cmd)
        {
            Write(cmd + "\n");
        }

        // Method to write to the telnet server
        public void Write(string cmd)
        {
            if (!tcpSocket.Connected) return;
            byte[] buf = System.Text.ASCIIEncoding.ASCII.GetBytes(cmd.Replace("\0xFF", "\0xFF\0xFF"));
            tcpSocket.GetStream().Write(buf, 0, buf.Length);
        }

        // Method to read from the telnet server
        public string Read()
        {
            if (!tcpSocket.Connected) return null;
            StringBuilder sb = new StringBuilder();
            do
            {
                ParseTelnet(sb);
                System.Threading.Thread.Sleep(TimeOutMs);
            } while (tcpSocket.Available > 0);
            return sb.ToString();
        }

        // Method to check if the connection is established
        public bool IsConnected
        {
            get { return tcpSocket.Connected; }
        }

        // Method to parse the telnet communication
        void ParseTelnet(StringBuilder sb)
        {
            while (tcpSocket.Available > 0)
            {
                int input = tcpSocket.GetStream().ReadByte();
                switch (input)
                {
                    case -1:
                        break;
                    case (int)Verbs.IAC:
                        // interpret as command
                        int inputverb = tcpSocket.GetStream().ReadByte();
                        if (inputverb == -1) break;
                        switch (inputverb)
                        {
                            case (int)Verbs.IAC:
                                //literal IAC = 255 escaped, so append char 255 to string
                                sb.Append(inputverb);
                                break;
                            case (int)Verbs.DO:
                            case (int)Verbs.DONT:
                            case (int)Verbs.WILL:
                            case (int)Verbs.WONT:
                                // reply to all commands with "WONT", unless it is SGA (suppress go ahead)
                                int inputoption = tcpSocket.GetStream().ReadByte();
                                if (inputoption == -1) break;
                                tcpSocket.GetStream().WriteByte((byte)Verbs.IAC);
                                if (inputoption == (int)Options.SGA)
                                    tcpSocket.GetStream().WriteByte(inputverb == (int)Verbs.DO ? (byte)Verbs.WILL : (byte)Verbs.DO);
                                else
                                    tcpSocket.GetStream().WriteByte(inputverb == (int)Verbs.DO ? (byte)Verbs.WONT : (byte)Verbs.DONT);
                                tcpSocket.GetStream().WriteByte((byte)inputoption);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        sb.Append((char)input);
                        break;
                }
            }
        }
    }
}

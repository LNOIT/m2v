namespace Move2VoiceBeta
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lblsideToMove = new System.Windows.Forms.Label();
            this.lblLastMove = new System.Windows.Forms.Label();
            this.lblAmIPlaying = new System.Windows.Forms.Label();
            this.tbGameString = new System.Windows.Forms.TextBox();
            this.pnlGameControls = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnMoves = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnReadLine = new System.Windows.Forms.Button();
            this.btnStopEngine = new System.Windows.Forms.Button();
            this.btnStartEngine = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlServer = new System.Windows.Forms.Panel();
            this.rtbGameMovesVerbose = new System.Windows.Forms.RichTextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rtbMainConsole = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbPrompt = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.pnlConnect = new System.Windows.Forms.Panel();
            this.lblPwd = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.pnlEngineAndCommunication = new System.Windows.Forms.Panel();
            this.rtbEngineOutPut = new System.Windows.Forms.RichTextBox();
            this.pnlTellsAndMoves = new System.Windows.Forms.Panel();
            this.rtbMovesListRaw = new System.Windows.Forms.RichTextBox();
            this.rtbPgn = new System.Windows.Forms.RichTextBox();
            this.rtbTells = new System.Windows.Forms.RichTextBox();
            this.rtbGames = new System.Windows.Forms.RichTextBox();
            this.rtbHelp = new System.Windows.Forms.RichTextBox();
            this.pnlDisplayRight = new System.Windows.Forms.Panel();
            this.pnlDebug = new System.Windows.Forms.Panel();
            this.btnTellsAndMoves = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnParseEngineLine = new System.Windows.Forms.Button();
            this.tbDebug = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDebugPieces = new System.Windows.Forms.Button();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMovesDebug = new System.Windows.Forms.Button();
            this.nudSpeachrate = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShowDebugPanel = new System.Windows.Forms.Button();
            this.lblLastBuildDate = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tbLastResponse = new System.Windows.Forms.TextBox();
            this.tmrEngine = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tmrRead = new System.Windows.Forms.Timer(this.components);
            this.tmrSmoothUpdate = new System.Windows.Forms.Timer(this.components);
            this.lblWhitePlayer = new System.Windows.Forms.Label();
            this.lblBlackPlayer = new System.Windows.Forms.Label();
            this.lblWhitesRemainingTime = new System.Windows.Forms.Label();
            this.lblBlacksRemainingTime = new System.Windows.Forms.Label();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.lblWhitesRemainingTimeFormated = new System.Windows.Forms.Label();
            this.lblBlacksRemainingTimeFormated = new System.Windows.Forms.Label();
            this.pnlGameControl = new System.Windows.Forms.Panel();
            this.pnlGameInfo = new System.Windows.Forms.Panel();
            this.tbSquareName = new System.Windows.Forms.TextBox();
            this.rtbMyGame = new System.Windows.Forms.RichTextBox();
            this.rtbLogGamestring = new System.Windows.Forms.RichTextBox();
            this.cbReverseBoard = new System.Windows.Forms.CheckBox();
            this.rtbSendHistory = new System.Windows.Forms.RichTextBox();
            this.tbClickOnTheSquareToMove = new System.Windows.Forms.TextBox();
            this.arrowkeyControllBox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.selectablePanel1 = new SelectablePanel();
            this.dgvGames = new System.Windows.Forms.DataGridView();
            this.GameIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RankWhite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameWhite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RankBlack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameBlack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBoard.SuspendLayout();
            this.pnlGameControls.SuspendLayout();
            this.pnlServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnlConnect.SuspendLayout();
            this.pnlEngineAndCommunication.SuspendLayout();
            this.pnlTellsAndMoves.SuspendLayout();
            this.pnlDisplayRight.SuspendLayout();
            this.pnlDebug.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeachrate)).BeginInit();
            this.pnlGameControl.SuspendLayout();
            this.pnlGameInfo.SuspendLayout();
            this.selectablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGames)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.AccessibleDescription = "";
            this.pnlBoard.AccessibleName = "The board";
            this.pnlBoard.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.pnlBoard.BackColor = System.Drawing.Color.DarkRed;
            this.pnlBoard.Controls.Add(this.richTextBox1);
            this.pnlBoard.Location = new System.Drawing.Point(9, 12);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(500, 500);
            this.pnlBoard.TabIndex = 1;
            this.pnlBoard.TabStop = true;
            this.pnlBoard.Tag = "The chessboard";
            this.pnlBoard.Enter += new System.EventHandler(this.pnlBoard_Enter);
            this.pnlBoard.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pnlBoard_PreviewKeyDown);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 22);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(174, 397);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            this.richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyDown);
            // 
            // lblsideToMove
            // 
            this.lblsideToMove.AutoSize = true;
            this.lblsideToMove.Location = new System.Drawing.Point(145, 196);
            this.lblsideToMove.Name = "lblsideToMove";
            this.lblsideToMove.Size = new System.Drawing.Size(76, 13);
            this.lblsideToMove.TabIndex = 6;
            this.lblsideToMove.Text = "lblsideToMove";
            // 
            // lblLastMove
            // 
            this.lblLastMove.AutoSize = true;
            this.lblLastMove.Location = new System.Drawing.Point(225, 196);
            this.lblLastMove.Name = "lblLastMove";
            this.lblLastMove.Size = new System.Drawing.Size(57, 13);
            this.lblLastMove.TabIndex = 17;
            this.lblLastMove.Text = "Last Move";
            // 
            // lblAmIPlaying
            // 
            this.lblAmIPlaying.AutoSize = true;
            this.lblAmIPlaying.Location = new System.Drawing.Point(365, 196);
            this.lblAmIPlaying.Name = "lblAmIPlaying";
            this.lblAmIPlaying.Size = new System.Drawing.Size(69, 13);
            this.lblAmIPlaying.TabIndex = 9;
            this.lblAmIPlaying.Text = "lblAmIPlaying";
            // 
            // tbGameString
            // 
            this.tbGameString.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGameString.Location = new System.Drawing.Point(98, 285);
            this.tbGameString.Name = "tbGameString";
            this.tbGameString.Size = new System.Drawing.Size(264, 23);
            this.tbGameString.TabIndex = 1;
            this.tbGameString.TabStop = false;
            this.tbGameString.Text = "4k2r/6r1/8/8/8/8/3R4/R3K3 w Qk - 0 1";
            // 
            // pnlGameControls
            // 
            this.pnlGameControls.Controls.Add(this.checkBox1);
            this.pnlGameControls.Controls.Add(this.button2);
            this.pnlGameControls.Controls.Add(this.btnMoves);
            this.pnlGameControls.Controls.Add(this.btnEnd);
            this.pnlGameControls.Controls.Add(this.btnReadLine);
            this.pnlGameControls.Controls.Add(this.btnStopEngine);
            this.pnlGameControls.Controls.Add(this.btnStartEngine);
            this.pnlGameControls.Controls.Add(this.btnStart);
            this.pnlGameControls.Controls.Add(this.btnForward);
            this.pnlGameControls.Controls.Add(this.btnBack);
            this.pnlGameControls.Location = new System.Drawing.Point(17, 13);
            this.pnlGameControls.Name = "pnlGameControls";
            this.pnlGameControls.Size = new System.Drawing.Size(480, 69);
            this.pnlGameControls.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(375, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(75, 23);
            this.checkBox1.TabIndex = 27;
            this.checkBox1.Text = "Voice";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(3, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.TabStop = false;
            this.button2.Text = "CreatePgn";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btnMoves
            // 
            this.btnMoves.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnMoves.Location = new System.Drawing.Point(93, 32);
            this.btnMoves.Name = "btnMoves";
            this.btnMoves.Size = new System.Drawing.Size(75, 23);
            this.btnMoves.TabIndex = 12;
            this.btnMoves.TabStop = false;
            this.btnMoves.Text = "Moves";
            this.btnMoves.UseVisualStyleBackColor = true;
            this.btnMoves.Click += new System.EventHandler(this.btnMoves_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEnd.Location = new System.Drawing.Point(281, 3);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(75, 23);
            this.btnEnd.TabIndex = 11;
            this.btnEnd.TabStop = false;
            this.btnEnd.Text = "End";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnReadLine
            // 
            this.btnReadLine.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnReadLine.Location = new System.Drawing.Point(336, 32);
            this.btnReadLine.Name = "btnReadLine";
            this.btnReadLine.Size = new System.Drawing.Size(75, 23);
            this.btnReadLine.TabIndex = 10;
            this.btnReadLine.TabStop = false;
            this.btnReadLine.Text = "Read line";
            this.btnReadLine.UseVisualStyleBackColor = true;
            this.btnReadLine.Click += new System.EventHandler(this.btnReadLine_Click);
            // 
            // btnStopEngine
            // 
            this.btnStopEngine.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnStopEngine.Location = new System.Drawing.Point(255, 32);
            this.btnStopEngine.Name = "btnStopEngine";
            this.btnStopEngine.Size = new System.Drawing.Size(75, 23);
            this.btnStopEngine.TabIndex = 1;
            this.btnStopEngine.TabStop = false;
            this.btnStopEngine.Text = "Stop Engine";
            this.btnStopEngine.UseVisualStyleBackColor = true;
            this.btnStopEngine.Click += new System.EventHandler(this.btnStopEngine_Click);
            // 
            // btnStartEngine
            // 
            this.btnStartEngine.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnStartEngine.Location = new System.Drawing.Point(174, 32);
            this.btnStartEngine.Name = "btnStartEngine";
            this.btnStartEngine.Size = new System.Drawing.Size(75, 23);
            this.btnStartEngine.TabIndex = 8;
            this.btnStartEngine.TabStop = false;
            this.btnStartEngine.Text = "Start Engine";
            this.btnStartEngine.UseVisualStyleBackColor = true;
            this.btnStartEngine.Click += new System.EventHandler(this.btnStartEngine_Click);
            // 
            // btnStart
            // 
            this.btnStart.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnStart.Location = new System.Drawing.Point(184, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 10;
            this.btnStart.TabStop = false;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnForward
            // 
            this.btnForward.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnForward.Location = new System.Drawing.Point(93, 3);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(75, 23);
            this.btnForward.TabIndex = 9;
            this.btnForward.TabStop = false;
            this.btnForward.Text = "Forward";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnBack
            // 
            this.btnBack.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBack.Location = new System.Drawing.Point(3, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 8;
            this.btnBack.TabStop = false;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pnlServer
            // 
            this.pnlServer.Controls.Add(this.rtbGameMovesVerbose);
            this.pnlServer.Controls.Add(this.dataGridView2);
            this.pnlServer.Controls.Add(this.rtbMainConsole);
            this.pnlServer.Controls.Add(this.panel2);
            this.pnlServer.Controls.Add(this.pnlConnect);
            this.pnlServer.Controls.Add(this.pnlEngineAndCommunication);
            this.pnlServer.Controls.Add(this.pnlDisplayRight);
            this.pnlServer.Location = new System.Drawing.Point(518, 6);
            this.pnlServer.Name = "pnlServer";
            this.pnlServer.Size = new System.Drawing.Size(926, 805);
            this.pnlServer.TabIndex = 2;
            // 
            // rtbGameMovesVerbose
            // 
            this.rtbGameMovesVerbose.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbGameMovesVerbose.Location = new System.Drawing.Point(518, 435);
            this.rtbGameMovesVerbose.Name = "rtbGameMovesVerbose";
            this.rtbGameMovesVerbose.Size = new System.Drawing.Size(408, 72);
            this.rtbGameMovesVerbose.TabIndex = 36;
            this.rtbGameMovesVerbose.TabStop = false;
            this.rtbGameMovesVerbose.Text = "";
            this.rtbGameMovesVerbose.WordWrap = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.EnableHeadersVisualStyles = false;
            this.dataGridView2.GridColor = System.Drawing.Color.LightGray;
            this.dataGridView2.Location = new System.Drawing.Point(518, 66);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView2.Name = "dataGridView2";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(406, 163);
            this.dataGridView2.TabIndex = 35;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Move";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 59;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "White";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 60;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Whites Time";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 91;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Black";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 59;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Blacks Time";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 90;
            // 
            // rtbMainConsole
            // 
            this.rtbMainConsole.AccessibleDescription = "Server responses";
            this.rtbMainConsole.AccessibleName = "Main Console";
            this.rtbMainConsole.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.rtbMainConsole.BackColor = System.Drawing.SystemColors.InfoText;
            this.rtbMainConsole.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMainConsole.ForeColor = System.Drawing.Color.Lime;
            this.rtbMainConsole.Location = new System.Drawing.Point(12, 67);
            this.rtbMainConsole.Name = "rtbMainConsole";
            this.rtbMainConsole.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbMainConsole.Size = new System.Drawing.Size(501, 440);
            this.rtbMainConsole.TabIndex = 2;
            this.rtbMainConsole.Text = "";
            this.rtbMainConsole.WordWrap = false;
            this.rtbMainConsole.TextChanged += new System.EventHandler(this.rtbMainConsole_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbPrompt);
            this.panel2.Controls.Add(this.btnSend);
            this.panel2.Location = new System.Drawing.Point(12, 513);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(874, 26);
            this.panel2.TabIndex = 13;
            // 
            // tbPrompt
            // 
            this.tbPrompt.AcceptsReturn = true;
            this.tbPrompt.AccessibleDescription = "Server commands";
            this.tbPrompt.AccessibleName = "Server commands";
            this.tbPrompt.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbPrompt.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPrompt.Location = new System.Drawing.Point(0, 0);
            this.tbPrompt.Name = "tbPrompt";
            this.tbPrompt.Size = new System.Drawing.Size(221, 23);
            this.tbPrompt.TabIndex = 0;
            this.tbPrompt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPrompt_KeyDown);
            this.tbPrompt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbPrompt_KeyUp);
            this.tbPrompt.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tbPrompt_PreviewKeyDown);
            // 
            // btnSend
            // 
            this.btnSend.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSend.Location = new System.Drawing.Point(226, 0);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(117, 22);
            this.btnSend.TabIndex = 12;
            this.btnSend.TabStop = false;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // pnlConnect
            // 
            this.pnlConnect.Controls.Add(this.lblPwd);
            this.pnlConnect.Controls.Add(this.btnTest);
            this.pnlConnect.Controls.Add(this.lblUser);
            this.pnlConnect.Controls.Add(this.tbUser);
            this.pnlConnect.Controls.Add(this.tbPassword);
            this.pnlConnect.Controls.Add(this.btnConnect);
            this.pnlConnect.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlConnect.Location = new System.Drawing.Point(0, 0);
            this.pnlConnect.Margin = new System.Windows.Forms.Padding(2);
            this.pnlConnect.Name = "pnlConnect";
            this.pnlConnect.Size = new System.Drawing.Size(926, 62);
            this.pnlConnect.TabIndex = 34;
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(99, 2);
            this.lblPwd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(53, 13);
            this.lblPwd.TabIndex = 36;
            this.lblPwd.Text = "Password";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(262, 19);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(89, 20);
            this.btnTest.TabIndex = 37;
            this.btnTest.Text = "button4";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(10, 2);
            this.lblUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(55, 13);
            this.lblUser.TabIndex = 35;
            this.lblUser.Text = "Username";
            // 
            // tbUser
            // 
            this.tbUser.AccessibleDescription = "Login prompt";
            this.tbUser.AccessibleName = "Login prompt";
            this.tbUser.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.tbUser.Location = new System.Drawing.Point(12, 19);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(84, 20);
            this.tbUser.TabIndex = 3;
            this.tbUser.TabStop = false;
            this.tbUser.Enter += new System.EventHandler(this.tbUser_Enter);
            this.tbUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbUser_KeyDown);
            // 
            // tbPassword
            // 
            this.tbPassword.AccessibleDescription = "Password";
            this.tbPassword.AccessibleName = "Password prompt";
            this.tbPassword.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.tbPassword.Location = new System.Drawing.Point(101, 19);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(74, 20);
            this.tbPassword.TabIndex = 4;
            this.tbPassword.TabStop = false;
            this.tbPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPassword_KeyDown);
            // 
            // btnConnect
            // 
            this.btnConnect.AccessibleDescription = "Connect Button";
            this.btnConnect.AccessibleName = "Connect Button";
            this.btnConnect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnConnect.Location = new System.Drawing.Point(181, 19);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 20);
            this.btnConnect.TabIndex = 11;
            this.btnConnect.TabStop = false;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // pnlEngineAndCommunication
            // 
            this.pnlEngineAndCommunication.Controls.Add(this.rtbEngineOutPut);
            this.pnlEngineAndCommunication.Controls.Add(this.pnlTellsAndMoves);
            this.pnlEngineAndCommunication.Controls.Add(this.rtbHelp);
            this.pnlEngineAndCommunication.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlEngineAndCommunication.Location = new System.Drawing.Point(0, 543);
            this.pnlEngineAndCommunication.Margin = new System.Windows.Forms.Padding(2);
            this.pnlEngineAndCommunication.Name = "pnlEngineAndCommunication";
            this.pnlEngineAndCommunication.Size = new System.Drawing.Size(926, 262);
            this.pnlEngineAndCommunication.TabIndex = 32;
            // 
            // rtbEngineOutPut
            // 
            this.rtbEngineOutPut.AccessibleDescription = "Where the computer line is shown";
            this.rtbEngineOutPut.AccessibleName = "Engine Console";
            this.rtbEngineOutPut.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.rtbEngineOutPut.AutoWordSelection = true;
            this.rtbEngineOutPut.BackColor = System.Drawing.Color.MidnightBlue;
            this.rtbEngineOutPut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbEngineOutPut.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbEngineOutPut.ForeColor = System.Drawing.SystemColors.Info;
            this.rtbEngineOutPut.Location = new System.Drawing.Point(0, 0);
            this.rtbEngineOutPut.Name = "rtbEngineOutPut";
            this.rtbEngineOutPut.Size = new System.Drawing.Size(926, 262);
            this.rtbEngineOutPut.TabIndex = 37;
            this.rtbEngineOutPut.TabStop = false;
            this.rtbEngineOutPut.Text = resources.GetString("rtbEngineOutPut.Text");
            this.rtbEngineOutPut.WordWrap = false;
            // 
            // pnlTellsAndMoves
            // 
            this.pnlTellsAndMoves.Controls.Add(this.rtbMovesListRaw);
            this.pnlTellsAndMoves.Controls.Add(this.rtbPgn);
            this.pnlTellsAndMoves.Controls.Add(this.rtbTells);
            this.pnlTellsAndMoves.Controls.Add(this.rtbGames);
            this.pnlTellsAndMoves.Location = new System.Drawing.Point(7, 6);
            this.pnlTellsAndMoves.Name = "pnlTellsAndMoves";
            this.pnlTellsAndMoves.Size = new System.Drawing.Size(205, 72);
            this.pnlTellsAndMoves.TabIndex = 20;
            this.pnlTellsAndMoves.Visible = false;
            // 
            // rtbMovesListRaw
            // 
            this.rtbMovesListRaw.BackColor = System.Drawing.Color.Indigo;
            this.rtbMovesListRaw.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMovesListRaw.ForeColor = System.Drawing.SystemColors.Info;
            this.rtbMovesListRaw.Location = new System.Drawing.Point(62, 15);
            this.rtbMovesListRaw.Name = "rtbMovesListRaw";
            this.rtbMovesListRaw.Size = new System.Drawing.Size(38, 39);
            this.rtbMovesListRaw.TabIndex = 5;
            this.rtbMovesListRaw.TabStop = false;
            this.rtbMovesListRaw.Text = "";
            this.rtbMovesListRaw.TextChanged += new System.EventHandler(this.rtbMovesListRaw_TextChanged);
            // 
            // rtbPgn
            // 
            this.rtbPgn.BackColor = System.Drawing.Color.DarkGreen;
            this.rtbPgn.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbPgn.ForeColor = System.Drawing.Color.White;
            this.rtbPgn.Location = new System.Drawing.Point(12, 15);
            this.rtbPgn.Name = "rtbPgn";
            this.rtbPgn.Size = new System.Drawing.Size(45, 39);
            this.rtbPgn.TabIndex = 6;
            this.rtbPgn.TabStop = false;
            this.rtbPgn.Text = "";
            // 
            // rtbTells
            // 
            this.rtbTells.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rtbTells.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbTells.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rtbTells.Location = new System.Drawing.Point(105, 15);
            this.rtbTells.Name = "rtbTells";
            this.rtbTells.Size = new System.Drawing.Size(38, 39);
            this.rtbTells.TabIndex = 4;
            this.rtbTells.TabStop = false;
            this.rtbTells.Text = "";
            this.rtbTells.TextChanged += new System.EventHandler(this.rtbTells_TextChanged);
            // 
            // rtbGames
            // 
            this.rtbGames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rtbGames.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbGames.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rtbGames.Location = new System.Drawing.Point(148, 15);
            this.rtbGames.Name = "rtbGames";
            this.rtbGames.Size = new System.Drawing.Size(42, 39);
            this.rtbGames.TabIndex = 3;
            this.rtbGames.TabStop = false;
            this.rtbGames.Text = "";
            this.rtbGames.TextChanged += new System.EventHandler(this.rtbGames_TextChanged);
            // 
            // rtbHelp
            // 
            this.rtbHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbHelp.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbHelp.Location = new System.Drawing.Point(0, 0);
            this.rtbHelp.Name = "rtbHelp";
            this.rtbHelp.Size = new System.Drawing.Size(926, 262);
            this.rtbHelp.TabIndex = 32;
            this.rtbHelp.TabStop = false;
            this.rtbHelp.Text = resources.GetString("rtbHelp.Text");
            this.rtbHelp.Visible = false;
            this.rtbHelp.WordWrap = false;
            // 
            // pnlDisplayRight
            // 
            this.pnlDisplayRight.Controls.Add(this.pnlDebug);
            this.pnlDisplayRight.Location = new System.Drawing.Point(555, 403);
            this.pnlDisplayRight.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDisplayRight.Name = "pnlDisplayRight";
            this.pnlDisplayRight.Size = new System.Drawing.Size(369, 440);
            this.pnlDisplayRight.TabIndex = 33;
            // 
            // pnlDebug
            // 
            this.pnlDebug.Controls.Add(this.btnTellsAndMoves);
            this.pnlDebug.Controls.Add(this.lblAmIPlaying);
            this.pnlDebug.Controls.Add(this.lblLastMove);
            this.pnlDebug.Controls.Add(this.btnRead);
            this.pnlDebug.Controls.Add(this.lblsideToMove);
            this.pnlDebug.Controls.Add(this.btnParseEngineLine);
            this.pnlDebug.Controls.Add(this.tbDebug);
            this.pnlDebug.Controls.Add(this.button3);
            this.pnlDebug.Controls.Add(this.label2);
            this.pnlDebug.Controls.Add(this.btnDebugPieces);
            this.pnlDebug.Controls.Add(this.rtbLog);
            this.pnlDebug.Controls.Add(this.richTextBox2);
            this.pnlDebug.Controls.Add(this.button1);
            this.pnlDebug.Controls.Add(this.btnMovesDebug);
            this.pnlDebug.Controls.Add(this.nudSpeachrate);
            this.pnlDebug.Controls.Add(this.label1);
            this.pnlDebug.Location = new System.Drawing.Point(14, 197);
            this.pnlDebug.Name = "pnlDebug";
            this.pnlDebug.Size = new System.Drawing.Size(332, 218);
            this.pnlDebug.TabIndex = 3;
            this.pnlDebug.Visible = false;
            // 
            // btnTellsAndMoves
            // 
            this.btnTellsAndMoves.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnTellsAndMoves.Location = new System.Drawing.Point(10, 191);
            this.btnTellsAndMoves.Name = "btnTellsAndMoves";
            this.btnTellsAndMoves.Size = new System.Drawing.Size(126, 23);
            this.btnTellsAndMoves.TabIndex = 26;
            this.btnTellsAndMoves.TabStop = false;
            this.btnTellsAndMoves.Text = "Tells Panel";
            this.btnTellsAndMoves.UseVisualStyleBackColor = true;
            this.btnTellsAndMoves.Click += new System.EventHandler(this.btnTellsAndMoves_Click);
            // 
            // btnRead
            // 
            this.btnRead.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRead.Location = new System.Drawing.Point(143, 170);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(138, 23);
            this.btnRead.TabIndex = 13;
            this.btnRead.TabStop = false;
            this.btnRead.Text = "Listening to server";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnParseEngineLine
            // 
            this.btnParseEngineLine.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnParseEngineLine.Location = new System.Drawing.Point(9, 130);
            this.btnParseEngineLine.Name = "btnParseEngineLine";
            this.btnParseEngineLine.Size = new System.Drawing.Size(128, 26);
            this.btnParseEngineLine.TabIndex = 25;
            this.btnParseEngineLine.TabStop = false;
            this.btnParseEngineLine.Text = "Parse Engine";
            this.btnParseEngineLine.UseVisualStyleBackColor = true;
            this.btnParseEngineLine.Click += new System.EventHandler(this.btnParseEngineLine_Click);
            // 
            // tbDebug
            // 
            this.tbDebug.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDebug.Location = new System.Drawing.Point(10, 101);
            this.tbDebug.Name = "tbDebug";
            this.tbDebug.Size = new System.Drawing.Size(127, 23);
            this.tbDebug.TabIndex = 24;
            this.tbDebug.TabStop = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.ForeColor = System.Drawing.Color.Yellow;
            this.button3.Location = new System.Drawing.Point(314, 220);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 23);
            this.button3.TabIndex = 22;
            this.button3.TabStop = false;
            this.button3.Text = "TEST";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "label2";
            // 
            // btnDebugPieces
            // 
            this.btnDebugPieces.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDebugPieces.Location = new System.Drawing.Point(9, 69);
            this.btnDebugPieces.Name = "btnDebugPieces";
            this.btnDebugPieces.Size = new System.Drawing.Size(128, 26);
            this.btnDebugPieces.TabIndex = 23;
            this.btnDebugPieces.TabStop = false;
            this.btnDebugPieces.Text = "Debug pieces";
            this.btnDebugPieces.UseVisualStyleBackColor = true;
            this.btnDebugPieces.Click += new System.EventHandler(this.btnDebugPieces_Click);
            // 
            // rtbLog
            // 
            this.rtbLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLog.Location = new System.Drawing.Point(295, 9);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(139, 176);
            this.rtbLog.TabIndex = 22;
            this.rtbLog.TabStop = false;
            this.rtbLog.Text = "";
            this.rtbLog.TextChanged += new System.EventHandler(this.rtbLog_TextChanged);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(143, 9);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(139, 176);
            this.richTextBox2.TabIndex = 21;
            this.richTextBox2.TabStop = false;
            this.richTextBox2.Text = "rnbqkbnr\npppppppp\n--------\n--------\n--------\n--------\nPPPPPPPP\nRNBQKBNR";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(10, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 23);
            this.button1.TabIndex = 18;
            this.button1.TabStop = false;
            this.button1.Text = "Convert to FEN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMovesDebug
            // 
            this.btnMovesDebug.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnMovesDebug.Location = new System.Drawing.Point(8, 37);
            this.btnMovesDebug.Name = "btnMovesDebug";
            this.btnMovesDebug.Size = new System.Drawing.Size(128, 26);
            this.btnMovesDebug.TabIndex = 18;
            this.btnMovesDebug.TabStop = false;
            this.btnMovesDebug.Text = "Debug moves";
            this.btnMovesDebug.UseVisualStyleBackColor = true;
            this.btnMovesDebug.Click += new System.EventHandler(this.btnMovesDebug_Click);
            // 
            // nudSpeachrate
            // 
            this.nudSpeachrate.AccessibleName = "Speechrate";
            this.nudSpeachrate.AccessibleRole = System.Windows.Forms.AccessibleRole.SpinButton;
            this.nudSpeachrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSpeachrate.Location = new System.Drawing.Point(9, 9);
            this.nudSpeachrate.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudSpeachrate.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.nudSpeachrate.Name = "nudSpeachrate";
            this.nudSpeachrate.Size = new System.Drawing.Size(120, 22);
            this.nudSpeachrate.TabIndex = 7;
            this.nudSpeachrate.TabStop = false;
            this.nudSpeachrate.Value = new decimal(new int[] {
            3,
            0,
            0,
            -2147483648});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(292, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // btnShowDebugPanel
            // 
            this.btnShowDebugPanel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnShowDebugPanel.Location = new System.Drawing.Point(368, 285);
            this.btnShowDebugPanel.Name = "btnShowDebugPanel";
            this.btnShowDebugPanel.Size = new System.Drawing.Size(75, 23);
            this.btnShowDebugPanel.TabIndex = 26;
            this.btnShowDebugPanel.TabStop = false;
            this.btnShowDebugPanel.Text = "Debug Panel";
            this.btnShowDebugPanel.UseVisualStyleBackColor = true;
            this.btnShowDebugPanel.Click += new System.EventHandler(this.btnShowDebugPanel_Click);
            // 
            // lblLastBuildDate
            // 
            this.lblLastBuildDate.AutoSize = true;
            this.lblLastBuildDate.Location = new System.Drawing.Point(13, 173);
            this.lblLastBuildDate.Name = "lblLastBuildDate";
            this.lblLastBuildDate.Size = new System.Drawing.Size(130, 13);
            this.lblLastBuildDate.TabIndex = 19;
            this.lblLastBuildDate.Text = "Last Build version: x Date:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.Coral;
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.SystemColors.WindowFrame;
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.AliceBlue;
            this.dateTimePicker1.CalendarTrailingForeColor = System.Drawing.Color.Green;
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(138, 167);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.TabStop = false;
            // 
            // tbLastResponse
            // 
            this.tbLastResponse.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLastResponse.Location = new System.Drawing.Point(17, 285);
            this.tbLastResponse.Name = "tbLastResponse";
            this.tbLastResponse.Size = new System.Drawing.Size(63, 23);
            this.tbLastResponse.TabIndex = 17;
            this.tbLastResponse.TabStop = false;
            this.tbLastResponse.TextChanged += new System.EventHandler(this.tbLastResponse_TextChanged);
            // 
            // tmrEngine
            // 
            this.tmrEngine.Interval = 5000;
            this.tmrEngine.Tick += new System.EventHandler(this.tmrEngine_Tick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "br.png");
            this.imageList1.Images.SetKeyName(1, "bn.png");
            this.imageList1.Images.SetKeyName(2, "bb.png");
            this.imageList1.Images.SetKeyName(3, "bq.png");
            this.imageList1.Images.SetKeyName(4, "bk.png");
            this.imageList1.Images.SetKeyName(5, "bp.png");
            this.imageList1.Images.SetKeyName(6, "wr.png");
            this.imageList1.Images.SetKeyName(7, "wn.png");
            this.imageList1.Images.SetKeyName(8, "wb.png");
            this.imageList1.Images.SetKeyName(9, "wq.png");
            this.imageList1.Images.SetKeyName(10, "wk.png");
            this.imageList1.Images.SetKeyName(11, "wp.png");
            this.imageList1.Images.SetKeyName(12, "clear.png");
            // 
            // tmrRead
            // 
            this.tmrRead.Interval = 200;
            this.tmrRead.Tick += new System.EventHandler(this.tmrRead_Tick);
            // 
            // tmrSmoothUpdate
            // 
            this.tmrSmoothUpdate.Interval = 1000;
            this.tmrSmoothUpdate.Tick += new System.EventHandler(this.tmrSmoothUpdate_Tick);
            // 
            // lblWhitePlayer
            // 
            this.lblWhitePlayer.AutoSize = true;
            this.lblWhitePlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhitePlayer.Location = new System.Drawing.Point(15, 107);
            this.lblWhitePlayer.Name = "lblWhitePlayer";
            this.lblWhitePlayer.Size = new System.Drawing.Size(50, 20);
            this.lblWhitePlayer.TabIndex = 7;
            this.lblWhitePlayer.Text = "White";
            // 
            // lblBlackPlayer
            // 
            this.lblBlackPlayer.AutoSize = true;
            this.lblBlackPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlackPlayer.Location = new System.Drawing.Point(199, 107);
            this.lblBlackPlayer.Name = "lblBlackPlayer";
            this.lblBlackPlayer.Size = new System.Drawing.Size(48, 20);
            this.lblBlackPlayer.TabIndex = 8;
            this.lblBlackPlayer.Text = "Black";
            // 
            // lblWhitesRemainingTime
            // 
            this.lblWhitesRemainingTime.AutoSize = true;
            this.lblWhitesRemainingTime.BackColor = System.Drawing.Color.White;
            this.lblWhitesRemainingTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhitesRemainingTime.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblWhitesRemainingTime.Location = new System.Drawing.Point(14, 9);
            this.lblWhitesRemainingTime.Name = "lblWhitesRemainingTime";
            this.lblWhitesRemainingTime.Size = new System.Drawing.Size(40, 24);
            this.lblWhitesRemainingTime.TabIndex = 10;
            this.lblWhitesRemainingTime.Text = "900";
            // 
            // lblBlacksRemainingTime
            // 
            this.lblBlacksRemainingTime.AutoSize = true;
            this.lblBlacksRemainingTime.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblBlacksRemainingTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlacksRemainingTime.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblBlacksRemainingTime.Location = new System.Drawing.Point(198, 9);
            this.lblBlacksRemainingTime.Name = "lblBlacksRemainingTime";
            this.lblBlacksRemainingTime.Size = new System.Drawing.Size(40, 24);
            this.lblBlacksRemainingTime.TabIndex = 11;
            this.lblBlacksRemainingTime.Text = "900";
            // 
            // tmrClock
            // 
            this.tmrClock.Enabled = true;
            this.tmrClock.Interval = 1000;
            this.tmrClock.Tick += new System.EventHandler(this.tmrClock_Tick);
            // 
            // lblWhitesRemainingTimeFormated
            // 
            this.lblWhitesRemainingTimeFormated.AutoSize = true;
            this.lblWhitesRemainingTimeFormated.BackColor = System.Drawing.Color.White;
            this.lblWhitesRemainingTimeFormated.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhitesRemainingTimeFormated.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblWhitesRemainingTimeFormated.Location = new System.Drawing.Point(14, 58);
            this.lblWhitesRemainingTimeFormated.Name = "lblWhitesRemainingTimeFormated";
            this.lblWhitesRemainingTimeFormated.Size = new System.Drawing.Size(40, 24);
            this.lblWhitesRemainingTimeFormated.TabIndex = 23;
            this.lblWhitesRemainingTimeFormated.Text = "900";
            // 
            // lblBlacksRemainingTimeFormated
            // 
            this.lblBlacksRemainingTimeFormated.AutoSize = true;
            this.lblBlacksRemainingTimeFormated.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblBlacksRemainingTimeFormated.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlacksRemainingTimeFormated.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblBlacksRemainingTimeFormated.Location = new System.Drawing.Point(198, 58);
            this.lblBlacksRemainingTimeFormated.Name = "lblBlacksRemainingTimeFormated";
            this.lblBlacksRemainingTimeFormated.Size = new System.Drawing.Size(40, 24);
            this.lblBlacksRemainingTimeFormated.TabIndex = 24;
            this.lblBlacksRemainingTimeFormated.Text = "900";
            // 
            // pnlGameControl
            // 
            this.pnlGameControl.AccessibleDescription = "";
            this.pnlGameControl.AccessibleName = "The board";
            this.pnlGameControl.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.pnlGameControl.BackColor = System.Drawing.Color.DarkRed;
            this.pnlGameControl.Controls.Add(this.pnlGameInfo);
            this.pnlGameControl.Controls.Add(this.pnlGameControls);
            this.pnlGameControl.Controls.Add(this.tbLastResponse);
            this.pnlGameControl.Controls.Add(this.tbGameString);
            this.pnlGameControl.Controls.Add(this.btnShowDebugPanel);
            this.pnlGameControl.Location = new System.Drawing.Point(12, 532);
            this.pnlGameControl.Name = "pnlGameControl";
            this.pnlGameControl.Size = new System.Drawing.Size(500, 317);
            this.pnlGameControl.TabIndex = 25;
            this.pnlGameControl.TabStop = true;
            this.pnlGameControl.Tag = "The chessboard";
            // 
            // pnlGameInfo
            // 
            this.pnlGameInfo.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.pnlGameInfo.Controls.Add(this.tbSquareName);
            this.pnlGameInfo.Controls.Add(this.rtbMyGame);
            this.pnlGameInfo.Controls.Add(this.rtbLogGamestring);
            this.pnlGameInfo.Controls.Add(this.cbReverseBoard);
            this.pnlGameInfo.Controls.Add(this.dateTimePicker1);
            this.pnlGameInfo.Controls.Add(this.lblLastBuildDate);
            this.pnlGameInfo.Controls.Add(this.rtbSendHistory);
            this.pnlGameInfo.Controls.Add(this.tbClickOnTheSquareToMove);
            this.pnlGameInfo.Controls.Add(this.lblWhitesRemainingTime);
            this.pnlGameInfo.Controls.Add(this.lblBlacksRemainingTimeFormated);
            this.pnlGameInfo.Controls.Add(this.lblWhitesRemainingTimeFormated);
            this.pnlGameInfo.Controls.Add(this.lblWhitePlayer);
            this.pnlGameInfo.Controls.Add(this.lblBlacksRemainingTime);
            this.pnlGameInfo.Controls.Add(this.lblBlackPlayer);
            this.pnlGameInfo.Location = new System.Drawing.Point(17, 88);
            this.pnlGameInfo.Name = "pnlGameInfo";
            this.pnlGameInfo.Size = new System.Drawing.Size(467, 191);
            this.pnlGameInfo.TabIndex = 26;
            // 
            // tbSquareName
            // 
            this.tbSquareName.Location = new System.Drawing.Point(81, 142);
            this.tbSquareName.Name = "tbSquareName";
            this.tbSquareName.Size = new System.Drawing.Size(52, 20);
            this.tbSquareName.TabIndex = 30;
            this.tbSquareName.TextChanged += new System.EventHandler(this.tbSquareName_TextChanged);
            // 
            // rtbMyGame
            // 
            this.rtbMyGame.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMyGame.Location = new System.Drawing.Point(311, 112);
            this.rtbMyGame.Name = "rtbMyGame";
            this.rtbMyGame.Size = new System.Drawing.Size(139, 35);
            this.rtbMyGame.TabIndex = 29;
            this.rtbMyGame.TabStop = false;
            this.rtbMyGame.Text = "";
            this.rtbMyGame.TextChanged += new System.EventHandler(this.rtbMyGame_TextChanged);
            // 
            // rtbLogGamestring
            // 
            this.rtbLogGamestring.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLogGamestring.Location = new System.Drawing.Point(302, 59);
            this.rtbLogGamestring.Name = "rtbLogGamestring";
            this.rtbLogGamestring.Size = new System.Drawing.Size(139, 35);
            this.rtbLogGamestring.TabIndex = 28;
            this.rtbLogGamestring.TabStop = false;
            this.rtbLogGamestring.Text = "";
            // 
            // cbReverseBoard
            // 
            this.cbReverseBoard.AutoSize = true;
            this.cbReverseBoard.Location = new System.Drawing.Point(158, 145);
            this.cbReverseBoard.Name = "cbReverseBoard";
            this.cbReverseBoard.Size = new System.Drawing.Size(97, 17);
            this.cbReverseBoard.TabIndex = 27;
            this.cbReverseBoard.Text = "Reverse Board";
            this.cbReverseBoard.UseVisualStyleBackColor = true;
            this.cbReverseBoard.Click += new System.EventHandler(this.cbReverseBoard_Click);
            // 
            // rtbSendHistory
            // 
            this.rtbSendHistory.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbSendHistory.Location = new System.Drawing.Point(311, 9);
            this.rtbSendHistory.Name = "rtbSendHistory";
            this.rtbSendHistory.Size = new System.Drawing.Size(139, 35);
            this.rtbSendHistory.TabIndex = 26;
            this.rtbSendHistory.TabStop = false;
            this.rtbSendHistory.Text = "";
            // 
            // tbClickOnTheSquareToMove
            // 
            this.tbClickOnTheSquareToMove.Location = new System.Drawing.Point(12, 142);
            this.tbClickOnTheSquareToMove.Name = "tbClickOnTheSquareToMove";
            this.tbClickOnTheSquareToMove.Size = new System.Drawing.Size(52, 20);
            this.tbClickOnTheSquareToMove.TabIndex = 25;
            // 
            // arrowkeyControllBox
            // 
            this.arrowkeyControllBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.arrowkeyControllBox.Location = new System.Drawing.Point(29, 518);
            this.arrowkeyControllBox.Name = "arrowkeyControllBox";
            this.arrowkeyControllBox.Size = new System.Drawing.Size(52, 20);
            this.arrowkeyControllBox.TabIndex = 32;
            this.arrowkeyControllBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.arrowkeyControllBox_KeyDown);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(90, 518);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(52, 20);
            this.textBox2.TabIndex = 31;
            // 
            // selectablePanel1
            // 
            this.selectablePanel1.Controls.Add(this.dgvGames);
            this.selectablePanel1.Location = new System.Drawing.Point(518, 816);
            this.selectablePanel1.Name = "selectablePanel1";
            this.selectablePanel1.Size = new System.Drawing.Size(926, 200);
            this.selectablePanel1.TabIndex = 40;
            // 
            // dgvGames
            // 
            this.dgvGames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvGames.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvGames.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvGames.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGames.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GameIndex,
            this.RankWhite,
            this.NameWhite,
            this.RankBlack,
            this.NameBlack,
            this.Type});
            this.dgvGames.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGames.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvGames.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvGames.EnableHeadersVisualStyles = false;
            this.dgvGames.GridColor = System.Drawing.Color.LightGray;
            this.dgvGames.Location = new System.Drawing.Point(0, 0);
            this.dgvGames.Margin = new System.Windows.Forms.Padding(2);
            this.dgvGames.Name = "dgvGames";
            this.dgvGames.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGames.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvGames.RowHeadersVisible = false;
            this.dgvGames.RowHeadersWidth = 51;
            this.dgvGames.RowTemplate.Height = 24;
            this.dgvGames.Size = new System.Drawing.Size(406, 200);
            this.dgvGames.TabIndex = 39;
            this.dgvGames.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView4_CellContentClick);
            this.dgvGames.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGames_CellEnter);
            this.dgvGames.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvGames_CellValuePushed);
            this.dgvGames.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvGames_KeyDown);
            this.dgvGames.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvGames_PreviewKeyDown);
            // 
            // GameIndex
            // 
            this.GameIndex.HeaderText = "Game Index";
            this.GameIndex.MinimumWidth = 6;
            this.GameIndex.Name = "GameIndex";
            this.GameIndex.ReadOnly = true;
            this.GameIndex.Width = 89;
            // 
            // RankWhite
            // 
            this.RankWhite.HeaderText = "Rank White";
            this.RankWhite.MinimumWidth = 6;
            this.RankWhite.Name = "RankWhite";
            this.RankWhite.ReadOnly = true;
            this.RankWhite.Width = 89;
            // 
            // NameWhite
            // 
            this.NameWhite.HeaderText = "Name White";
            this.NameWhite.MinimumWidth = 6;
            this.NameWhite.Name = "NameWhite";
            this.NameWhite.ReadOnly = true;
            this.NameWhite.Width = 91;
            // 
            // RankBlack
            // 
            this.RankBlack.HeaderText = "Rank Black";
            this.RankBlack.MinimumWidth = 6;
            this.RankBlack.Name = "RankBlack";
            this.RankBlack.ReadOnly = true;
            this.RankBlack.Width = 88;
            // 
            // NameBlack
            // 
            this.NameBlack.HeaderText = "Name Black";
            this.NameBlack.MinimumWidth = 6;
            this.NameBlack.Name = "NameBlack";
            this.NameBlack.ReadOnly = true;
            this.NameBlack.Width = 90;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 56;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(2553, 860);
            this.Controls.Add(this.selectablePanel1);
            this.Controls.Add(this.pnlBoard);
            this.Controls.Add(this.arrowkeyControllBox);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.pnlGameControl);
            this.Controls.Add(this.pnlServer);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "FrmMain";
            this.Text = "Move to voice";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load_1);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmMain_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyUp);
            this.MouseEnter += new System.EventHandler(this.FrmMain_MouseEnter);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FrmMain_PreviewKeyDown);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            this.pnlBoard.ResumeLayout(false);
            this.pnlGameControls.ResumeLayout(false);
            this.pnlServer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlConnect.ResumeLayout(false);
            this.pnlConnect.PerformLayout();
            this.pnlEngineAndCommunication.ResumeLayout(false);
            this.pnlTellsAndMoves.ResumeLayout(false);
            this.pnlDisplayRight.ResumeLayout(false);
            this.pnlDebug.ResumeLayout(false);
            this.pnlDebug.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeachrate)).EndInit();
            this.pnlGameControl.ResumeLayout(false);
            this.pnlGameControl.PerformLayout();
            this.pnlGameInfo.ResumeLayout(false);
            this.pnlGameInfo.PerformLayout();
            this.selectablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.TextBox tbGameString;
        private System.Windows.Forms.Panel pnlGameControls;
        private System.Windows.Forms.Panel pnlServer;
        private System.Windows.Forms.RichTextBox rtbMainConsole;
        private System.Windows.Forms.Panel pnlDebug;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnStartEngine;
        private System.Windows.Forms.Button btnStopEngine;
        private System.Windows.Forms.Button btnReadLine;
        private System.Windows.Forms.TextBox tbPrompt;
        private System.Windows.Forms.TextBox tbLastResponse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer tmrEngine;
        private System.Windows.Forms.RichTextBox rtbPgn;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer tmrRead;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnMoves;
        public System.Windows.Forms.RichTextBox rtbMovesListRaw;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer tmrSmoothUpdate;
        public System.Windows.Forms.Label lblsideToMove;
        public System.Windows.Forms.Label lblWhitePlayer;
        public System.Windows.Forms.Label lblBlackPlayer;
        public System.Windows.Forms.Label lblAmIPlaying;
        public System.Windows.Forms.Label lblWhitesRemainingTime;
        public System.Windows.Forms.Label lblBlacksRemainingTime;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox rtbTells;
        private System.Windows.Forms.RichTextBox rtbGames;
        public System.Windows.Forms.NumericUpDown nudSpeachrate;
        public System.Windows.Forms.TextBox tbPassword;
        public System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Timer tmrClock;
        public System.Windows.Forms.Label lblLastMove;
        private System.Windows.Forms.Button btnMovesDebug;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox rtbLog;
        public System.Windows.Forms.Label lblLastBuildDate;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDebugPieces;
        private System.Windows.Forms.TextBox tbDebug;
        private System.Windows.Forms.Button btnParseEngineLine;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.Label lblWhitesRemainingTimeFormated;
        public System.Windows.Forms.Label lblBlacksRemainingTimeFormated;
        private System.Windows.Forms.Panel pnlTellsAndMoves;
        private System.Windows.Forms.Panel pnlGameControl;
        private System.Windows.Forms.Panel pnlGameInfo;
        private System.Windows.Forms.Button btnShowDebugPanel;
        private System.Windows.Forms.Button btnTellsAndMoves;
        private System.Windows.Forms.TextBox tbClickOnTheSquareToMove;
        private System.Windows.Forms.RichTextBox rtbSendHistory;
        private System.Windows.Forms.CheckBox cbReverseBoard;
        private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.RichTextBox rtbMyGame;
		private System.Windows.Forms.RichTextBox rtbLogGamestring;
		private System.Windows.Forms.TextBox tbSquareName;
		private System.Windows.Forms.TextBox arrowkeyControllBox;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Panel pnlDisplayRight;
		private System.Windows.Forms.Panel pnlEngineAndCommunication;
		private System.Windows.Forms.Panel pnlConnect;
		private System.Windows.Forms.Label lblPwd;
		private System.Windows.Forms.Label lblUser;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.RichTextBox rtbGameMovesVerbose;
		private System.Windows.Forms.RichTextBox rtbHelp;
		public System.Windows.Forms.RichTextBox rtbEngineOutPut;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.DataGridView dgvGames;
        private System.Windows.Forms.DataGridViewTextBoxColumn GameIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn RankWhite;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameWhite;
        private System.Windows.Forms.DataGridViewTextBoxColumn RankBlack;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameBlack;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private SelectablePanel selectablePanel1;
    }
}


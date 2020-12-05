namespace BattleShip
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.gameProccesser = new System.Windows.Forms.Timer(this.components);
            this.btnStartGame = new System.Windows.Forms.Button();
            this.lbHowToPlayTitle = new System.Windows.Forms.Label();
            this.lbHowToPlayContent = new System.Windows.Forms.Label();
            this.ckbSound = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // gameProccesser
            // 
            this.gameProccesser.Interval = 8;
            this.gameProccesser.Tick += new System.EventHandler(this.OnUpdate);
            // 
            // btnStartGame
            // 
            this.btnStartGame.BackColor = System.Drawing.Color.Transparent;
            this.btnStartGame.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnStartGame.ForeColor = System.Drawing.Color.Black;
            this.btnStartGame.Location = new System.Drawing.Point(209, 298);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(164, 60);
            this.btnStartGame.TabIndex = 0;
            this.btnStartGame.Text = "PLAY";
            this.btnStartGame.UseVisualStyleBackColor = false;
            this.btnStartGame.Click += new System.EventHandler(this.StartGame);
            // 
            // lbHowToPlayTitle
            // 
            this.lbHowToPlayTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbHowToPlayTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHowToPlayTitle.ForeColor = System.Drawing.Color.White;
            this.lbHowToPlayTitle.Location = new System.Drawing.Point(16, 361);
            this.lbHowToPlayTitle.Name = "lbHowToPlayTitle";
            this.lbHowToPlayTitle.Size = new System.Drawing.Size(556, 30);
            this.lbHowToPlayTitle.TabIndex = 1;
            this.lbHowToPlayTitle.Text = "How to play";
            this.lbHowToPlayTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbHowToPlayContent
            // 
            this.lbHowToPlayContent.BackColor = System.Drawing.Color.Transparent;
            this.lbHowToPlayContent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHowToPlayContent.ForeColor = System.Drawing.Color.White;
            this.lbHowToPlayContent.Location = new System.Drawing.Point(17, 391);
            this.lbHowToPlayContent.Name = "lbHowToPlayContent";
            this.lbHowToPlayContent.Size = new System.Drawing.Size(555, 119);
            this.lbHowToPlayContent.TabIndex = 2;
            this.lbHowToPlayContent.Text = "Just like Chicken Invaders you\'d already played. \r\n- Move cursor to move your Bat" +
    "tle Ship.\r\n- Click to fireee.\r\n- Press \"P\" to pause/unpause.\r\nHope your enjoyy!!" +
    "!!";
            this.lbHowToPlayContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ckbSound
            // 
            this.ckbSound.BackColor = System.Drawing.Color.Transparent;
            this.ckbSound.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ckbSound.ForeColor = System.Drawing.Color.White;
            this.ckbSound.Location = new System.Drawing.Point(12, 924);
            this.ckbSound.Name = "ckbSound";
            this.ckbSound.Size = new System.Drawing.Size(125, 25);
            this.ckbSound.TabIndex = 3;
            this.ckbSound.Text = "Sound Effect";
            this.ckbSound.UseVisualStyleBackColor = false;
            this.ckbSound.CheckedChanged += new System.EventHandler(this.ToggleSound);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = global::BattleShip.Properties.Resources.bg1;
            this.ClientSize = new System.Drawing.Size(584, 961);
            this.Controls.Add(this.ckbSound);
            this.Controls.Add(this.lbHowToPlayContent);
            this.Controls.Add(this.lbHowToPlayTitle);
            this.Controls.Add(this.btnStartGame);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BBQ Chicken Invaders";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameProccesser;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Label lbHowToPlayTitle;
        private System.Windows.Forms.Label lbHowToPlayContent;
        private System.Windows.Forms.CheckBox ckbSound;
    }
}


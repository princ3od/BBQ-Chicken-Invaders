using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip
{
    public partial class frmMain : Form
    {
        BattleShip mainBattleShip;
        ChickenArmy chickenArmy;
        BackgroundController backgroundController;
        Timer backgroundLoader;
        bool gameOver = true, gamePause = false;
        Random chickenLocation;
        const int MAX_chicken = 10;
        bool XRAY = false;
        int delaychicken = 300;
        int score;
        StringFormat SF = new StringFormat();
        public frmMain()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            backgroundController = new BackgroundController(Properties.Resources.bg1, this.Size);
            backgroundController.Speed = 1;
            backgroundLoader = new Timer();
            backgroundLoader.Interval = 20;
            backgroundLoader.Tick += (s, ev) =>
            {
                this.Invalidate();
            };
            backgroundLoader.Start();
            SF.Alignment = StringAlignment.Near;
            ckbSound.Checked = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            backgroundController.Render(e.Graphics);
            if (mainBattleShip != null)
            {
                mainBattleShip.Render(e.Graphics, XRAY);
                foreach (Rocket rocket in mainBattleShip.Rockets)
                {
                    rocket.Render(e.Graphics, XRAY);
                }
            }
            if (chickenArmy != null)
                foreach (Chicken chicken in chickenArmy.Chickens)
                {
                    chicken.Render(e.Graphics, XRAY);
                }
            if (!gameOver)
            {
                SF.Alignment = StringAlignment.Near;
                e.Graphics.DrawString("Score: " + score.ToString(), this.Font, new SolidBrush(Color.White), new RectangleF(0, 0, this.ClientSize.Width, 20), SF);
            }
            else
            {
                if (btnStartGame.Text == "PLAY AGAIN")
                {
                    SF.Alignment = StringAlignment.Center;
                    SF.LineAlignment = StringAlignment.Center;
                    e.Graphics.DrawString("Your Score: " + score.ToString(), this.Font, new SolidBrush(Color.White), new RectangleF(0, 360, this.ClientSize.Width, 20), SF);
                }
            }
            if (gamePause)
            {
                SF.Alignment = StringAlignment.Center;
                SF.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString("Press \"P\" to continue playing.", this.Font, new SolidBrush(Color.DarkRed), new RectangleF(0, 400, this.ClientSize.Width, 20), SF);
            }

        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (gameOver)
                return;
            if (e.Location.Y < this.Height - 80 && e.Location.Y > 40 && !gamePause)
                mainBattleShip.Fly(e.Location);
            //this.Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (!gameOver && !gamePause)
                PauseGame();
        }
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if (!gameOver && !gamePause)
                PauseGame();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (gamePause)
                PauseGame();
            if (gameOver || !gameProccesser.Enabled)
                return;
            mainBattleShip.mode = BattleShip.Mode.Firing;
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (gameOver || !gameProccesser.Enabled)
                return;
            mainBattleShip.mode = BattleShip.Mode.Normal;
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.T:
                    XRAY = !XRAY;
                    break;
                case Keys.Space:
                    mainBattleShip.Fire();
                    break;
                case Keys.P:
                    PauseGame();
                    break;
            }
        }
        private void OnUpdate(object sender, EventArgs e)
        {
            if (gameOver)
            {
                gameProccesser.Stop();
                backgroundController.Speed = 1;
                backgroundLoader.Start();
                btnStartGame.Show();
                btnStartGame.Text = "PLAY AGAIN";
                return;
            }
            for (int i = 0; i < chickenArmy.Chickens.Count;)
            {
                if (mainBattleShip.IsCollison(chickenArmy.Chickens[i]))
                {
                    gameOver = true;
                    mainBattleShip.Boom();
                }
                if (chickenArmy.Chickens[i].IsOutOfFrame(this.Size))
                    chickenArmy.Chickens.RemoveAt(i);
                else
                {
                    chickenArmy.Chickens[i].Move(Direction.Down);
                    i++;
                }

            }
            for (int i = 0; i < mainBattleShip.Rockets.Count;)
            {
                foreach (var chicken in chickenArmy.Chickens)
                {
                    if (mainBattleShip.Rockets[i].IsBoom)
                        break;
                    if (mainBattleShip.Rockets[i].IsCollison(chicken))
                    {
                        mainBattleShip.Rockets[i].Boom();
                        chickenArmy.Chickens.Remove(chicken);
                        score++;
                        mainBattleShip.Power = score;
                        break;
                    }
                }
                if (mainBattleShip.Rockets[i].IsOutOfFrame(this.Size))
                    mainBattleShip.Rockets.RemoveAt(i);
                else if (mainBattleShip.Rockets[i].IsBoom)
                {
                    if (mainBattleShip.Rockets[i].BoomTime <= 0)
                        mainBattleShip.Rockets.RemoveAt(i);
                    else
                    {
                        mainBattleShip.Rockets[i].BoomTime -= 1;
                        i++;
                    }
                }
                else
                {
                    mainBattleShip.Rockets[i].Move(Direction.Up);
                    i++;
                }
            }
            if (delaychicken == 0 && !gameOver)
            {
                int countMons = chickenLocation.Next(1, 7);
                chickenArmy.Generate(countMons, score);
                delaychicken = chickenLocation.Next(30, 100);
            }
            else
            {
                delaychicken--;
            }
            this.Invalidate();
        }

        private void StartGame(object sender, EventArgs e)
        {
            backgroundLoader.Stop();
            backgroundController.Speed = 6;
            mainBattleShip = new BattleShip(Properties.Resources.battleship, new Point(this.Width / 2 - 25, this.Height - 120), new Size(70, 80), 10);
            chickenArmy = new ChickenArmy(this.ClientSize);
            chickenLocation = new Random((int)DateTime.Now.Ticks);
            score = 0;
            gameOver = false;
            gameProccesser.Start();
            btnStartGame.Visible = lbHowToPlayContent.Visible = lbHowToPlayTitle.Visible = gamePause = false;
        }

        private void ToggleSound(object sender, EventArgs e)
        {
            SoundHelper.SoundOn = ckbSound.Checked;
        }

        void PauseGame()
        {
            if (gameOver)
                return;
            gamePause = !gamePause;
            if (gamePause)
            {
                lbHowToPlayTitle.Text = "GAME PAUSED";
                lbHowToPlayTitle.ForeColor = Color.DarkRed;
                lbHowToPlayTitle.Show();
                if (gameProccesser.Enabled)
                    gameProccesser.Stop();
            }
            else
            {
                lbHowToPlayTitle.Text = "How To Play";
                lbHowToPlayTitle.ForeColor = Color.White;
                lbHowToPlayTitle.Hide();
                if (!gameOver)
                    gameProccesser.Start();
            }
            this.Invalidate();
        }
    }
}

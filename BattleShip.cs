using System.Collections.Generic;
using System.Drawing;

namespace BattleShip
{
    class BattleShip : GameObject
    {
        public List<Rocket> Rockets;
        enum ShootType { One = 0, Two = 2, Three = 4, Four = 6, Five = 8 };
        ShootType shootType;
        public enum Mode { Normal, Firing };
        public Mode mode;
        const int RECOIL_MAX = 6;
        int recoil = 0;
        private int power;
        int hotGun;

        public int Power
        {
            get => power;
            set
            {
                power = value;
                if (power > 300)
                    shootType = ShootType.Five;
                else if (power > 140)
                    shootType = ShootType.Four;
                else if (power > 50)
                    shootType = ShootType.Three;
                else if (power > 20)
                    shootType = ShootType.Two;
            }
        }

        public BattleShip(Image _texture, Point _location, Size _size, int _speed) : base(_texture, _location, _size, _speed)
        {
            Rockets = new List<Rocket>();
            shootType = ShootType.One;
            mode = Mode.Normal;
            hotGun = 0;
            power = 0;
        }
        public void Fly(Point _newLocation)
        {
            this.Location = new Point(_newLocation.X - this.size.Width / 2, _newLocation.Y - this.size.Height / 2);
        }
        public void Fire()
        {
            if (recoil > 0)
                return;
            switch (shootType)
            {
                case ShootType.One:
                    Rockets.Add(new Rocket(Properties.Resources.rocket, new Point(this.location.X + this.size.Width / 2 - 9, this.location.Y - 10),
                new Size(18, 28), 15, Properties.Resources.boom, false));
                    break;
                case ShootType.Two:
                    Rockets.Add(new Rocket(Properties.Resources.rocket, new Point(this.location.X + this.size.Width / 2 - 27, this.location.Y - 7),
                new Size(18, 28), 16, Properties.Resources.boom, false));
                    Rockets.Add(new Rocket(Properties.Resources.rocket, new Point(this.location.X + this.size.Width / 2 + 9, this.location.Y - 7),
                new Size(18, 28), 16, Properties.Resources.boom, false));
                    break;
                case ShootType.Three:
                    Rockets.Add(new Rocket(Properties.Resources.rocket, new Point(this.location.X + this.size.Width / 2 - 9, this.location.Y - 10),
               new Size(18, 28), 19, Properties.Resources.boom, false));
                    Rockets.Add(new Rocket(Properties.Resources.rocket, new Point(this.location.X + this.size.Width / 2 - 45, this.location.Y - 8),
                new Size(18, 28), 17, Properties.Resources.boom, false));
                    Rockets.Add(new Rocket(Properties.Resources.rocket, new Point(this.location.X + this.size.Width / 2 + 27, this.location.Y - 8),
                new Size(18, 28), 17, Properties.Resources.boom, false));
                    break;
                case ShootType.Four:
                    Rockets.Add(new Rocket(Properties.Resources.rocket, new Point(this.location.X + this.size.Width / 2 - 25, this.location.Y - 2),
                new Size(18, 28), 22, Properties.Resources.boom, false));
                    Rockets.Add(new Rocket(Properties.Resources.rocket, new Point(this.location.X + this.size.Width / 2 + 7, this.location.Y - 2),
                new Size(18, 28), 22, Properties.Resources.boom, false));
                    Rockets.Add(new Rocket(Properties.Resources.rocket, new Point(this.location.X + this.size.Width / 2 - 44, this.location.Y - 2),
               new Size(18, 28), 20, Properties.Resources.boom, false));
                    Rockets.Add(new Rocket(Properties.Resources.rocket, new Point(this.location.X + this.size.Width / 2 + 26, this.location.Y - 2),
                new Size(18, 28), 20, Properties.Resources.boom, false));
                    break;
                case ShootType.Five:
                    Rockets.Add(new Rocket(Properties.Resources.rocket, new Point(this.location.X + this.size.Width / 2 - 9, this.location.Y - 10),
                new Size(18, 28), 23, Properties.Resources.boom, false));
                    Rockets.Add(new Rocket(Properties.Resources.rocket, new Point(this.location.X + this.size.Width / 2 - 25, this.location.Y - 2),
               new Size(18, 28), 22, Properties.Resources.boom, false));
                    Rockets.Add(new Rocket(Properties.Resources.rocket, new Point(this.location.X + this.size.Width / 2 + 7, this.location.Y - 2),
                new Size(18, 28), 22, Properties.Resources.boom, false));
                    Rockets.Add(new Rocket(Properties.Resources.rocket, new Point(this.location.X + this.size.Width / 2 - 44, this.location.Y - 2),
               new Size(18, 28), 21, Properties.Resources.boom, false));
                    Rockets.Add(new Rocket(Properties.Resources.rocket, new Point(this.location.X + this.size.Width / 2 + 26, this.location.Y - 2),
                new Size(18, 28), 21, Properties.Resources.boom, false));
                    break;
                default:
                    break;
            }

            SoundHelper.Play(Properties.Resources.shoting1);
            recoil = RECOIL_MAX + (int)shootType / 2;
        }
        public override void Boom()
        {
            this.size = new Size(90, 90);
            this.location = new Point(this.location.X - 10, this.location.Y - 8);
            this.texture = Properties.Resources.boom;
            SoundHelper.Play(Properties.Resources.big_explosion);
        }
        public override void Render(Graphics graphics, bool showRec = false)
        {
            if (recoil > RECOIL_MAX / 2)
            {
                speed = 4;
                Move(Direction.Down);
                recoil--;
            }
            else if (recoil > 0)
            {
                speed = 4;
                Move(Direction.Up);
                recoil--;
            }
            base.Render(graphics, showRec);
            if (mode == Mode.Firing)
            {
                if (hotGun == 0)
                {
                    Fire();
                    hotGun = 6 + (int)shootType * 2;
                }
                else
                    hotGun--;
            }
            else
            {
                hotGun = 0;
            }
        }
    }
}

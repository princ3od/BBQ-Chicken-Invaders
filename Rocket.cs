using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Rocket : GameObject
    {
        private Image effect;
        private bool isBoom;
        int BOOM_TIME = 6;
        public Image Effect { get => effect; set => effect = value; }
        public bool IsBoom { get => isBoom; set => isBoom = value; }
        public int BoomTime { get; set; }

        public Rocket(Image _texture, Point _location, Size _size, int _speed, Image effect, bool isBoom) : base(_texture, _location, _size, _speed)
        {
            Effect = effect;
            IsBoom = isBoom;
            speed += 15;
        }
        public override void Boom()
        {
            isBoom = true;
            BoomTime = BOOM_TIME;
            this.texture = Properties.Resources.boom2;
            this.size = new Size(28, 28);
            SoundHelper.Play(Properties.Resources.rocket_explosion);
            //this.location = new Point(this.location.X, this.location.Y - 4);
        }
    }
}

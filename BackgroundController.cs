using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class BackgroundController
    {
        class Background : GameObject
        {
            public Background(Image _texture, Point _location, Size _size, int _speed) : base(_texture, _location, _size, _speed)
            {

            }
        }
        Image texture;
        Size canvasSize;
        private int speed;
        private List<Background> backgrounds = new List<Background>();
        public BackgroundController(Image _texture, Size _canvasSize, int _speed = 6)
        {
            texture = _texture;
            canvasSize = _canvasSize;
            speed = _speed;
            for (int i = 0; i < 2; i++)
            {
                Background background = new Background(_texture, new Point(0, i * _canvasSize.Height), new Size(_canvasSize.Width, _canvasSize.Height + 20), speed);
                backgrounds.Add(background);
            }
        }

        public int Speed
        {
            get => speed;
            set
            {
                foreach (Background background in backgrounds)
                {
                    background.Speed = value;
                }
                speed = value;
            }
        }

        public void Render(Graphics graphics)
        {
            foreach (Background background in backgrounds)
                background.Render(graphics);
            Move();
        }
        public void Move(Direction direction = Direction.Down)
        {
            foreach (Background background in backgrounds)
            {
                background.Move(direction);
                if (background.IsOutOfFrame(this.canvasSize))
                    background.Location = new Point(0, -background.Size.Height + 10);
            }
        }
    }
}

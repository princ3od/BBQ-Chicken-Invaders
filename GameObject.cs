using System.Drawing;
using System.Media;

namespace BattleShip
{
    enum Direction { Up, Down, Left, Right };
    abstract class GameObject
    {
        protected Image texture;
        protected Point location;
        protected Size size;
        protected int speed;
        protected GameObject(Image texture, Point location, Size size, int speed)
        {
            this.texture = texture;
            this.location = location;
            this.size = size;
            this.speed = speed;
        }

        public Image Texture { get => texture; set => texture = value; }
        public Point Location { get => location; set => location = value; }
        public Size Size { get => size; set => size = value; }
        public int Speed { get => speed; set => speed = value; }
        public Rectangle Rec { get => new Rectangle(location, Size); }
        virtual public void Render(Graphics graphics, bool showRec = false)
        {
            graphics.DrawImage(this.texture,
                                new Rectangle(this.location, this.size), new Rectangle(0, 0, this.texture.Width, this.texture.Height),
                                    GraphicsUnit.Pixel);
            if (showRec)
                graphics.DrawRectangle(new Pen(new SolidBrush(Color.WhiteSmoke)), this.Rec);
        }
        virtual public void Move(Direction _direction)
        {
            switch (_direction)
            {
                case Direction.Up:
                    location.Y -= speed;
                    break;
                case Direction.Down:
                    location.Y += speed;
                    break;
                case Direction.Left:
                    location.X -= speed;
                    break;
                case Direction.Right:
                    location.X += speed;
                    break;
                default:
                    break;
            }
        }
        virtual public bool IsCollison(GameObject _gameObject)
        {
            return this.Rec.IntersectsWith(_gameObject.Rec);
        }
        virtual public bool IsOutOfFrame(Size _frameSize)
        {
            return !(new Rectangle(0, 0, _frameSize.Width, _frameSize.Height).IntersectsWith(this.Rec));
        }
        virtual public void Boom() { }
    }
}

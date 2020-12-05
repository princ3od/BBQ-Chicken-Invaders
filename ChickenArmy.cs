using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class ChickenArmy
    {
        public Size CanvasSize;
        public List<Chicken> Chickens;
        Random random;
        public ChickenArmy(Size canvasSize)
        {
            Chickens = new List<Chicken>();
            CanvasSize = canvasSize;
            random = new Random();
        }
        public void Generate(int _chickNum, int _score)
        {
            int additionOnPlayLong = _score / 20;
            additionOnPlayLong = random.Next(0, additionOnPlayLong);
            for (int i = 0; i < _chickNum + additionOnPlayLong; i++)
            {
                Image chickenTexture = (random.Next(1, 10) > 5) ? Properties.Resources.chicken1 : Properties.Resources.chicken2;
                Chicken chicken = new Chicken(chickenTexture, new Point(random.Next(0, CanvasSize.Width - 60), 0 - random.Next(0, 5) * 15),
                    new Size(60, 60), 5);
                Chickens.Add(chicken);
            }
        }

    }
}

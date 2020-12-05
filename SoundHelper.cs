using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class SoundHelper
    {
        public static bool SoundOn = true;
        public static void Play(Stream _sound)
        {
            if (!SoundOn)
                return;
            SoundPlayer soundPlayer = new SoundPlayer(_sound);
            soundPlayer.Play();
        }
    }
}

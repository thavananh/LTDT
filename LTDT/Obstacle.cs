using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTDT
{
    class Obstacle
    {
        private int idImage;
        private Image asset;

        public int IdImage { get => idImage; set => idImage = value; }
        public Image Asset { get => asset; set => asset = value; }

        public Obstacle(int id, Bitmap asset)
        {
            this.IdImage = id;
            this.Asset = asset;
        }
    }
}

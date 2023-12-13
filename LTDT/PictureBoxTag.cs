using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTDT
{
    class PictureBoxTag
    {
        private int rowIndex;
        private int imageTag;
        private int colIndex;

        public int RowIndex { get => rowIndex; set => rowIndex = value; }
        public int ImageTag { get => imageTag; set => imageTag = value; }
        public int ColIndex { get => colIndex; set => colIndex = value; }

        public PictureBoxTag()
        {
            this.RowIndex = -1;
            this.ColIndex = -1;
            this.ImageTag = 0;
        }

        public PictureBoxTag(buttonTag btnTag)
        {
            this.RowIndex = btnTag.RowIndex;
            this.ColIndex = btnTag.ColIndex;
            this.ImageTag = btnTag.ImageTag;
        }
    }
}

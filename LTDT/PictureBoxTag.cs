using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTDT
{
    class PictureBoxTag
    {
        private int _rowIndex;
        private int _imageTag;
        public int RowIndex { get => _rowIndex; set => _rowIndex = value; }
        public int ImageTag { get => _imageTag; set => _imageTag = value; }

        public PictureBoxTag()
        {
            this.RowIndex = -1;
            this.ImageTag = 0;
        }

        public PictureBoxTag(PictureBoxTag ptcbTag)
        {
            this.RowIndex = ptcbTag.RowIndex;
            this.ImageTag = ptcbTag.ImageTag;
        }
    }
}

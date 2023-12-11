using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTDT
{
    class buttonTag
    {
        private int rowIndex;
        private int imageTag;

        public int RowIndex { get => rowIndex; set => rowIndex = value; }
        public int ImageTag { get => imageTag; set => imageTag = value; }

        public buttonTag()
        {
            this.RowIndex = -1;
            this.ImageTag = 0;
        }

        public buttonTag(buttonTag btnTag)
        {
            this.RowIndex = btnTag.RowIndex;
            this.ImageTag = btnTag.ImageTag;
        }
    }
}

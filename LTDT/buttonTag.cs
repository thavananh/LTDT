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
        private int colIndex;
        private int nodeID;

        public int RowIndex { get => rowIndex; set => rowIndex = value; }
        public int ImageTag { get => imageTag; set => imageTag = value; }
        public int ColIndex { get => colIndex; set => colIndex = value; }
        public int NodeID { get => nodeID; set => nodeID = value; }

        public buttonTag(int rowIndex = -1, int colIndex = -1, int imageTag = 0, int nodeId = -1)
        {
            this.RowIndex = rowIndex;
            this.ColIndex = colIndex;
            this.ImageTag = imageTag;
            this.nodeID = nodeId;
        }

        public buttonTag(buttonTag btnTag)
        {
            this.RowIndex = btnTag.RowIndex;
            this.ColIndex = btnTag.ColIndex;
            this.ImageTag = btnTag.ImageTag;
            this.nodeID = btnTag.NodeID;
        }
    }
}

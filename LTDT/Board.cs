using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTDT
{
    public class Board
    {
        private GradientPanel _boardPanel;
        private List<List<Button>> _matrixButton;
        private Obstacle _rock = new Obstacle(1, Properties.Resources.rocks);
        private Obstacle _snowman = new Obstacle(2, Properties.Resources.snowman);
        private Obstacle _tree = new Obstacle(3, Properties.Resources.tree);
        private Dictionary<int, Obstacle> _randObstacles;
        private int _totalButtonSelect = 0;

        public List<List<Button>> MatrixButton { get => _matrixButton; set => _matrixButton = value; }
        public GradientPanel BoardPanel { get => _boardPanel; set => _boardPanel = value; }

        public Board(GradientPanel boardPanel)
        {
            this.BoardPanel = boardPanel;
            _randObstacles = new Dictionary<int, Obstacle>()
            {
                {1, _rock},
                {2, _snowman},
                {3, _tree}
            };
        }

        private void btnPanel_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (_totalButtonSelect == 0)
            {
                btn.BackgroundImage = Properties.Resources.placeholder;
            }
            else if (_totalButtonSelect == 1)
            {
                btn.BackgroundImage = Properties.Resources.destination;
            }
            Random rand = new Random();
            int randNum = rand.Next(1, 4);
            btn.BackgroundImage = _randObstacles[randNum].Asset;
            buttonTag tagTmp = (buttonTag)btn.Tag;
            tagTmp.ImageTag = _randObstacles[randNum].IdImage;
            btn.Tag = tagTmp;
            _totalButtonSelect++;
        }

        public void drawBoardPanel()
        {
            MatrixButton = new List<List<Button>>();
            for (int i = 0; i < ConstantVar.ROW_NUMBER; i++)
            {
                for (int j = 0; j < ConstantVar.COL_NUMBER; j++)
                {
                    Button btn = new Button()
                    {
                        Width = ConstantVar.BTNPANEL_WIDTH,
                        Height = ConstantVar.BTNPANEL_HEIGHT,
                        Location = new Point(j * ConstantVar.BTNPANEL_WIDTH, i * ConstantVar.BTNPANEL_HEIGHT),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = new buttonTag() {RowIndex = 0}
                    };
                    btn.Click += btnPanel_Click;
                    BoardPanel.Controls.Add(btn);
                    MatrixButton[i].Add(btn);
                }
            }
        }
    }
}

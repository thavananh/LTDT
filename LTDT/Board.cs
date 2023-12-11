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
        private GradientPanel boardPanel;
        private List<List<Button>> matrixButton;
        private Obstacle rock = new Obstacle(1, Properties.Resources.rocks);
        private Obstacle snowman = new Obstacle(2, Properties.Resources.snowman);
        private Obstacle tree = new Obstacle(3, Properties.Resources.tree);
        private int totalButtonSelect = 0;

        public List<List<Button>> MatrixButton { get => matrixButton; set => matrixButton = value; }
        internal GradientPanel BoardPanel { get => boardPanel; set => boardPanel = value; }

        public Board()
        {

        }

        private void btnPanel_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (totalButtonSelect == 0)
            {
                btn.BackgroundImage = Properties.Resources.placeholder;
            }
            else if (totalButtonSelect == 1)
            {
                btn.BackgroundImage = Properties.Resources.destination;
            }

            btn.BackgroundImage = Properties.Resources.rocks;
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
                        Tag = i.ToString() // dùng để lưu hàng của btn
                    };
                    btn.Click += btnPanel_Click;
                    BoardPanel.Controls.Add(btn);
                    MatrixButton[i].Add(btn);
                }
            }
        }
    }
}

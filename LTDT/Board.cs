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
        private Timer _timer = new Timer()
        {
            Interval = 1,
        };

        private PictureBox manPctb;

        public List<List<Button>> MatrixButton { get => _matrixButton; set => _matrixButton = value; }
        public GradientPanel BoardPanel { get => _boardPanel; set => _boardPanel = value; }
        public PictureBox ManPctb { get => manPctb; set => manPctb = value; }

        public Board(GradientPanel boardPanel)
        {
            this.BoardPanel = boardPanel;
            _randObstacles = new Dictionary<int, Obstacle>()
            {
                {1, _rock},
                {2, _snowman},
                {3, _tree}
            };
            _timer.Tick += Timer_Tick;
        }

        private void btnPanel_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (((buttonTag)btn.Tag).ImageTag != 0)
            {
                btn.BackgroundImage = null;
                buttonTag tagTmp = (buttonTag)btn.Tag;
                tagTmp.ImageTag = 0;
                btn.Tag = tagTmp;
            }
            if (_totalButtonSelect == 0)
            {
                btn.BackgroundImage = Properties.Resources.placeholder;
                buttonTag tagTmp = (buttonTag)btn.Tag;
                tagTmp.ImageTag = 4;
                btn.Tag = tagTmp;
                ManPctb = new PictureBox()
                {
                    Width = 30,
                    Height = 30,
                    //Location = new Point(ConstantVar.BTNPANEL_WIDTH, ConstantVar.BTNPANEL_HEIGHT), // x y
                    Location = new Point(btn.Location.X + 5, btn.Location.Y + 5),
                    BackgroundImageLayout = ImageLayout.Stretch,
                    Tag = new buttonTag() { RowIndex = tagTmp.RowIndex },
                    BackgroundImage = Properties.Resources.man,
                    BackColor = Color.Transparent,
                    BorderStyle = BorderStyle.FixedSingle
                };
                BoardPanel.Controls.Add(ManPctb);
                ManPctb.BringToFront();
                //btn.SendToBack();
            }
            else if (_totalButtonSelect == 1)
            {
                btn.BackgroundImage = Properties.Resources.destination;
                buttonTag tagTmp = (buttonTag)btn.Tag;
                tagTmp.ImageTag = 5;
                btn.Tag = tagTmp;
            }
            else
            {
                Random rand = new Random();
                int randNum = rand.Next(1, 4);
                btn.BackgroundImage = _randObstacles[randNum].Asset;
                buttonTag tagTmp = (buttonTag)btn.Tag;
                tagTmp.ImageTag = _randObstacles[randNum].IdImage;
                btn.Tag = tagTmp;
            }
            _totalButtonSelect++;
        }

        private int stopTimer = 0;
        private int destButtonRowIndex = 0;
        private int destButtonColIndex = 1;
        private int manPctbStartLocation = 0;
        private string movedDirection = "";

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (manPctb.Location.X == getButton(destButtonRowIndex, destButtonColIndex).Location.X + manPctbStartLocation)
            {
                _timer.Stop();
                return;
            }
            MoveObject(2);
            stopTimer++;
        }

        public void drawBoardPanel()
        {
            MatrixButton = new List<List<Button>>();
            for (int i = 0; i < ConstantVar.ROW_NUMBER; i++)
            {
                MatrixButton.Add(new List<Button>());
                for (int j = 0; j < ConstantVar.COL_NUMBER; j++)
                {
                    Button btn = new Button()
                    {
                        Width = ConstantVar.BTNPANEL_WIDTH,
                        Height = ConstantVar.BTNPANEL_HEIGHT,
                        Location = new Point(j * ConstantVar.BTNPANEL_WIDTH, i * ConstantVar.BTNPANEL_HEIGHT),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = new buttonTag() {RowIndex = 0},
                    };
                    btn.Click += btnPanel_Click;
                    BoardPanel.Controls.Add(btn);
                    MatrixButton[i].Add(btn);
                }
            }
        }

        private Button getButton(int i, int j)
        {
            return MatrixButton[destButtonRowIndex][destButtonColIndex];
        }

        public void XuLyDiChuyen()
        {
            manPctbStartLocation = manPctb.Location.X;
            _timer.Start();
            manPctb.BringToFront();
        }

        private void MoveObject(int speed)
        {
            ManPctb.Left += speed;
        }
    }
}

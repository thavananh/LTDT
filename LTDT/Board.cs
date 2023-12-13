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
        private int destButtonColIndex = 0;
        private int manPctbStartLocationX = 0;
        private int manPctbStartLocationY = 0;
        private string movedDirection = "left";

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (movedDirection == "up")
            {
                if (manPctb.Location.Y == getButton(destButtonRowIndex, destButtonColIndex).Location.Y + 5)
                {
                    _timer.Stop();
                    tcs.SetResult(true);
                    return;
                }
                MoveObjectTUp(2);
            }
            else if (movedDirection == "down")
            {
                if (manPctb.Location.Y == getButton(destButtonRowIndex, destButtonColIndex).Location.Y + 5)
                {
                    _timer.Stop();
                    tcs.SetResult(true);
                    return;
                }
                MoveObjectDown(2);
            }
            else if (movedDirection == "left")
            {
                if (manPctb.Location.X == getButton(destButtonRowIndex, destButtonColIndex).Location.X + 5)
                {
                    _timer.Stop();
                    tcs.SetResult(true);
                    return;
                }
                MoveObjectLeft(2);
            }
            else if (movedDirection == "right")
            {
                if (manPctb.Location.X == getButton(destButtonRowIndex, destButtonColIndex).Location.X + 5)
                {
                    _timer.Stop();
                    tcs.SetResult(true);
                    return;
                }
                MoveObjectRight(2);
            }
            else
            {
                _timer.Stop();
                tcs.SetResult(true);
            }
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

        private TaskCompletionSource<bool> tcs;
        private TaskCompletionSource<bool> tcs1;

        public async void XuLyDiChuyen()
        {
            tcs = new TaskCompletionSource<bool>();
            tcs1 = new TaskCompletionSource<bool>();
            manPctbStartLocationX = manPctb.Location.X;
            manPctbStartLocationY = manPctb.Location.Y;
            manPctb.BringToFront();
            _timer.Start();
            await tcs.Task;
            await Task.Delay(1000);
            tcs1.SetResult(true);
        }

        public async void startDoingThing()
        {
            int preRowIndex = 0;
            int preColIndex = 0;
            for (int i = 0; i < 1; ++i)
            {
                for (int j = 0; j < MatrixButton[i].Count; j++)
                {
                    movedDirection = GetDirection(preRowIndex, preColIndex, i, j);
                    destButtonRowIndex = i;
                    destButtonColIndex = j;
                    XuLyDiChuyen();
                    await tcs1.Task;
                }
            }
        }

        private string GetDirection(int preRowIndex, int preColIndex, int newRowIndex, int newColIndex)
        {
            if (newRowIndex > preRowIndex)
            {
                return "down";
            }

            if (newRowIndex < preRowIndex)
            {
                return "up";
            }

            if (newColIndex > preColIndex)
            {
                return "right";
            }

            if (newColIndex < preColIndex)
            {
                return "left";
            }

            return "";
        }

        private void MoveObjectRight(int speed)
        {
            ManPctb.Left += speed;
        }

        private void MoveObjectLeft(int speed)
        {
            ManPctb.Left -= speed;
        }

        private void MoveObjectTUp(int speed)
        {
            ManPctb.Top -= speed;
        }

        private void MoveObjectDown(int speed)
        {
            ManPctb.Top += speed;
        }
    }
}

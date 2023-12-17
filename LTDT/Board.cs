using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
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
        private List<List<int>> adjList;
        private List<List<int>> adjList_original;
        private Obstacle _rock = new Obstacle(1, Properties.Resources.rocks);
        private Obstacle _snowman = new Obstacle(2, Properties.Resources.snowman);
        private Obstacle _tree = new Obstacle(3, Properties.Resources.tree);
        private Dictionary<int, Obstacle> _randObstacles;
        private int _totalButtonSelect = 0;
        private Timer _timer = new Timer()
        {
            Interval = 1,
        };
        

        private List<bool> visited;

        private PictureBox manPctb;

        public List<List<Button>> MatrixButton { get => _matrixButton; set => _matrixButton = value; }
        public GradientPanel BoardPanel { get => _boardPanel; set => _boardPanel = value; }
        public PictureBox ManPctb { get => manPctb; set => manPctb = value; }
        public TaskCompletionSource<bool> Tcs3 { get => tcs3; set => tcs3 = value; }
        public TaskCompletionSource<bool> Tcs2 { get => tcs2; set => tcs2 = value; }
        public List<List<int>> AdjList { get => adjList; set => adjList = value; }

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
            visited = new List<bool>();
            for (int i = 0; i < ConstantVar.COL_NUMBER * ConstantVar.ROW_NUMBER; i++)
            {
                visited.Add(false);
            }
        }

        private void btnPanel_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.BackgroundImage != null || isRun == true)
            {
                return;
            }
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
                    Tag = new PictureBoxTag() { RowIndex = tagTmp.RowIndex, ColIndex = tagTmp.ColIndex},
                    BackgroundImage = Properties.Resources.man,
                    BackColor = Color.Transparent,
                    BorderStyle = BorderStyle.FixedSingle
                };
                BoardPanel.Controls.Add(ManPctb);
                //ManPctb.BringToFront();
                //btn.SendToBack();
            }
            else if (_totalButtonSelect == 1)
            {
                btn.BackgroundImage = Properties.Resources.destination;
                buttonTag tagTmp = (buttonTag)btn.Tag;
                tagTmp.ImageTag = 5;
                btn.Tag = tagTmp;
                int nodeID = getNodeId(tagTmp.RowIndex, tagTmp.ColIndex);
                for (int i = 0; i < ConstantVar.ROW_NUMBER * ConstantVar.COL_NUMBER; i++)
                {
                    if (adjList[i][nodeID] != 0)
                    {
                        adjList[i][nodeID] = 2804;
                    }
                }
            }
            else
            {
                Random rand = new Random();
                int randNum = rand.Next(1, 4);
                btn.BackgroundImage = _randObstacles[randNum].Asset;
                buttonTag tagTmp = (buttonTag)btn.Tag;
                tagTmp.ImageTag = _randObstacles[randNum].IdImage;
                btn.Tag = tagTmp;
                int nodeID = getNodeId(tagTmp.RowIndex, tagTmp.ColIndex);
                for (int i = 0; i < ConstantVar.ROW_NUMBER * ConstantVar.COL_NUMBER; i++)
                {
                    adjList[i][nodeID] = 0;
                    adjList[nodeID][i] = 0;
                }
            }

            _totalButtonSelect++;
        }

        private int destButtonRowIndex = 0;
        private int destButtonColIndex = 0;
        //private int manPctbStartLocationX = 0;
        //private int manPctbStartLocationY = 0;
        private string movedDirection = "";

        private void Timer_Tick(object sender, EventArgs e)
        {
            int btnDestLocationY = getButton(destButtonRowIndex, destButtonColIndex).Location.Y;
            int btnDestLocationX = getButton(destButtonRowIndex, destButtonColIndex).Location.X;
            if (movedDirection == "up")
            {
                if (manPctb.Location.Y == btnDestLocationY + 5)
                {
                    _timer.Stop();
                    tcs.SetResult(true);
                    return;
                }
                MoveObjectTUp(2);
            }
            else if (movedDirection == "down")
            {
                if (manPctb.Location.Y == btnDestLocationY + 5)
                {
                    _timer.Stop();
                    tcs.SetResult(true);
                    return;
                }
                MoveObjectDown(2);
            }
            else if (movedDirection == "left")
            {
                if (manPctb.Location.X == btnDestLocationX + 5)
                {
                    _timer.Stop();
                    tcs.SetResult(true);
                    return;
                }
                MoveObjectLeft(2);
            }
            else if (movedDirection == "right")
            {
                if (manPctb.Location.X == btnDestLocationX + 5)
                {
                    _timer.Stop();
                    tcs.SetResult(true);
                    return;
                }
                MoveObjectRight(2);
            }
            else if (movedDirection == "rightbottom")
            {
                if (ManPctb.Location.X == btnDestLocationX + 5 && ManPctb.Location.Y == btnDestLocationY + 5) 
                {
                    _timer.Stop();
                    tcs.SetResult(true);
                    return;
                }
                MoveObjectRightBottom(2);
            }
            else if (movedDirection == "leftbottom")
            {
                if (ManPctb.Location.X == btnDestLocationX + 5 && ManPctb.Location.Y == btnDestLocationY + 5)
                {
                    _timer.Stop();
                    tcs.SetResult(true);
                    return;
                }
                MoveObjectLeftBottom(2);
            }
            else if (movedDirection == "righttop")
            {
                if (ManPctb.Location.X == btnDestLocationX + 5 && ManPctb.Location.Y == btnDestLocationY + 5)
                {
                    _timer.Stop();
                    tcs.SetResult(true);
                    return;
                }
                MoveObjectRightTop(2);
            }
            else if (movedDirection == "lefttop")
            {
                if (ManPctb.Location.X == btnDestLocationX + 5 && ManPctb.Location.Y == btnDestLocationY + 5)
                {
                    _timer.Stop();
                    tcs.SetResult(true);
                    return;
                }
                MoveObjectLeftTop(2);
            }
            else if (movedDirection == "teleport")
            {
                _timer.Stop();
                manPctb.Left = btnDestLocationX + 5;
                manPctb.Top = btnDestLocationY + 5;
                tcs.SetResult(true);
                return;
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
            adjList = new List<List<int>>();
            adjList_original = new List<List<int>>();
            for (int i = 0; i < ConstantVar.ROW_NUMBER * ConstantVar.COL_NUMBER; i++)
            {
                AdjList.Add(new List<int>(ConstantVar.ROW_NUMBER * ConstantVar.COL_NUMBER));
                adjList_original.Add(new List<int>(ConstantVar.ROW_NUMBER * ConstantVar.COL_NUMBER));
                for (int j = 0; j < ConstantVar.ROW_NUMBER * ConstantVar.COL_NUMBER; j++)
                {
                    AdjList[i].Add(0);
                    adjList_original[i].Add(0);
                }
            }

            int soNode = 0;
            
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
                        BackColor = SystemColors.Control,
                        UseVisualStyleBackColor = true,
                        Tag = new buttonTag(i, j, 0, soNode),
                    };
                    btn.Click += btnPanel_Click;
                    BoardPanel.Controls.Add(btn);
                    MatrixButton[i].Add(btn);
                    soNode++;
                }
            }

            soNode = 0;

            for (int i = 0; i < ConstantVar.ROW_NUMBER; i++)
            {
                for (int j = 0; j < ConstantVar.COL_NUMBER; j++)
                {
                    
                    if (j + 1 > 0 && j + 1 < ConstantVar.COL_NUMBER)
                    {
                        AdjList[soNode][getNodeId(i, j + 1)] = 1;
                        adjList_original[soNode][getNodeId(i, j + 1)] = 1;
                    }

                    if (j - 1 >= 0)
                    {
                        AdjList[soNode][getNodeId(i, j - 1)] = 1;
                        adjList_original[soNode][getNodeId(i, j - 1)] = 1;
                    }

                    if (i + 1 > 0 && i + 1 < ConstantVar.ROW_NUMBER)
                    {
                        AdjList[soNode][getNodeId(i + 1, j)] = 1;
                        adjList_original[soNode][getNodeId(i + 1, j)] = 1;
                    }

                    if (i - 1 >= 0)
                    {
                        AdjList[soNode][getNodeId(i - 1, j)] = 1;
                        adjList_original[soNode][getNodeId(i - 1, j)] = 1;
                    }

                    /*PhÍA Trên là trên dưới trái phải*/

                    if ((j + 1 > 0 && j + 1 < ConstantVar.COL_NUMBER) && (i + 1 > 0 && i + 1 < ConstantVar.ROW_NUMBER)) // right bottom
                    {
                        AdjList[soNode][getNodeId(i + 1, j + 1)] = 1;
                        adjList_original[soNode][getNodeId(i + 1, j + 1)] = 1;
                    }

                    if ((j + 1 > 0 && j + 1 < ConstantVar.COL_NUMBER) && i - 1 >= 0)//right top
                    {
                        AdjList[soNode][getNodeId(i - 1, j + 1)] = 1;
                        adjList_original[soNode][getNodeId(i - 1, j + 1)] = 1;
                    }

                    if (j - 1 >= 0 && (i + 1 > 0 && i + 1 < ConstantVar.ROW_NUMBER)) // left bottom
                    {
                        AdjList[soNode][getNodeId(i + 1, j - 1)] = 1;
                        adjList_original[soNode][getNodeId(i + 1, j - 1)] = 1;
                    }

                    if (j - 1 >= 0 && i - 1 >= 0)
                    {
                        AdjList[soNode][getNodeId(i - 1, j - 1)] = 1;
                        adjList_original[soNode][getNodeId(i - 1, j - 1)] = 1;
                    }
                    soNode++;
                }
            }

            

            //frmMain.instance.MaTranKe.Text += (ConstantVar.COL_NUMBER * ConstantVar.ROW_NUMBER).ToString() + "\n";

            //for (int i = 0; i < AdjList.Count; i++)
            //{
            //    for (int j = 0; j < AdjList[i].Count; j++)
            //    {
            //        frmMain.instance.MaTranKe.Text += AdjList[i][j].ToString() + " ";
            //    }

            //    frmMain.instance.MaTranKe.Text += "\n";
            //}
        }

        private Button getButton(int i, int j)
        {
            return MatrixButton[destButtonRowIndex][destButtonColIndex];
        }

        private int getNodeId(int i, int j)
        {
            return ((buttonTag)MatrixButton[i][j].Tag).NodeID;
        }

        private TaskCompletionSource<bool> tcs;
        private TaskCompletionSource<bool> tcs1;
        private TaskCompletionSource<bool> tcs2;
        private bool isRun = false;

        public async void XuLyDiChuyen()
        {
            tcs = new TaskCompletionSource<bool>();
            tcs1 = new TaskCompletionSource<bool>();
            //manPctbStartLocationX = manPctb.Location.X;
            //manPctbStartLocationY = manPctb.Location.Y;
            ManPctb.BringToFront();
            _timer.Start();
            await tcs.Task;
            await Task.Delay(0); // điều khiển di chuyển nhanh chậm
            tcs1.SetResult(true);

        }

        public async void startDoingThing()
        {
            
            PictureBoxTag pctbTag = (PictureBoxTag)manPctb.Tag;
            for (int i = pctbTag.RowIndex; i < MatrixButton.Count; ++i)
            {
                for (int j = pctbTag.ColIndex; j < MatrixButton[i].Count; j++)
                {
                    movedDirection = GetDirection(pctbTag.RowIndex, pctbTag.ColIndex, i, j);
                    destButtonRowIndex = i;
                    destButtonColIndex = j;
                    XuLyDiChuyen();
                    await tcs1.Task;
                }
            }
        }

        private Button getButtonByNodeId(int id)
        {
            for (int i = 0; i < MatrixButton.Count; i++)
            {
                for (int j = 0; j < MatrixButton[i].Count; j++)
                {
                    if (((buttonTag)MatrixButton[i][j].Tag).NodeID == id)
                    {
                        return MatrixButton[i][j];
                    }
                }
            }
            return null;
        }

        public async void dfs()
        {
            int dem = 0;
            isRun = true;
            Tcs2 = new TaskCompletionSource<bool>();
            PictureBoxTag pctbTag = (PictureBoxTag)manPctb.Tag;
            Stack<int> stc = new Stack<int>();
            int startVertices = getNodeId(pctbTag.RowIndex, pctbTag.ColIndex);
            stc.Push(startVertices);
            int totalNode = ConstantVar.COL_NUMBER * ConstantVar.ROW_NUMBER;
            visited[startVertices] = true;
            int lastVisitNode = -1;
            int lastVertices;
            //string filePath = @"C:\Users\thava\source\repos\debugDfs\debugDfs\output_dfs_csharp_1.txt";
            //using (StreamWriter writer = new StreamWriter(filePath, true))
            //{
            //writer.WriteLine(startVertices.ToString());
            frmMain.instance.KetQua.Text += "Đỉnh bắt đầu: " + startVertices.ToString() + "\n" + "Đường đi: ";
                while (stc.Count > 0)
                {
                    
                    if (dem == totalNode - 1)
                    {
                        break;
                    }
                    int v = stc.Peek();
                    int flag = 0;
                    
                    for (int i = 0; i < totalNode; i++)
                    {
                        if (!visited[i] && AdjList[v][i] != 0)
                        {
                            visited[i] = true;
                            frmMain.instance.KetQua.Text += i + " ";
                            stc.Push(i);
                            //writer.Write(i.ToString() + " ");
                            buttonTag tmp = (buttonTag)getButtonByNodeId(i).Tag;
                            movedDirection = GetDirection(pctbTag.RowIndex, pctbTag.ColIndex, tmp.RowIndex,
                                tmp.ColIndex);
                            destButtonRowIndex = tmp.RowIndex;
                            destButtonColIndex = tmp.ColIndex;
                            pctbTag.RowIndex = tmp.RowIndex;
                            pctbTag.ColIndex = tmp.ColIndex;
                            XuLyDiChuyen();
                            await tcs1.Task;
                            MatrixButton[destButtonRowIndex][destButtonColIndex].BackColor = Color.Lime;
                            dem++;
                            flag = 1;
                            lastVisitNode = i;
                            break;
                        }
                    }
                    
                    if (flag == 0)
                    {
                        stc.Pop();
                    }
                    if (lastVisitNode != -1 && adjList[v][lastVisitNode] == 2804)
                    {
                        tcs2.SetResult(true);
                        MessageBox.Show("Đã tới đích", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        isRun = false;
                        return;
                    }
                }
            //writer.WriteLine();
            frmMain.instance.KetQua.Text += "\n";
        //}
            Tcs2.SetResult(true);
            isRun = false;
        }

        public async void bfs()
        {
            isRun = true;
            Tcs2 = new TaskCompletionSource<bool>();
            PictureBoxTag pctbTag = (PictureBoxTag)manPctb.Tag;
            Queue<int> q = new Queue<int>();
            int startVertices = getNodeId(pctbTag.RowIndex, pctbTag.ColIndex);
            q.Enqueue(startVertices);
            visited[startVertices] = true;
            int totalNode = ConstantVar.COL_NUMBER * ConstantVar.ROW_NUMBER;
            //string filePath = @"C:\Users\thava\source\repos\debugDfs\debugDfs\output_bfs_csharp.txt";
            frmMain.instance.KetQua.Text += "Đỉnh bắt đầu: " + startVertices.ToString() + "\n" + "Đường đi: ";
            //using (StreamWriter writer = new StreamWriter(filePath, true))
            //{
                //writer.WriteLine(startVertices.ToString());
                while (q.Count > 0)
                {
                    int v = q.Peek();
                    frmMain.instance.KetQua.Text += v + " ";
                    //writer.Write(v.ToString() + " ");
                    q.Dequeue();
                    for (int i = 0; i < totalNode; ++i)
                    {
                        if (!visited[i] && AdjList[v][i] != 0)
                        {
                            q.Enqueue(i);
                            visited[i] = true;
                            frmMain.instance.KetQua.Text += i + " ";
                            buttonTag tmp = (buttonTag)getButtonByNodeId(i).Tag;
                            movedDirection = GetDirection(pctbTag.RowIndex, pctbTag.ColIndex, tmp.RowIndex,
                                tmp.ColIndex);
                            destButtonRowIndex = tmp.RowIndex;
                            destButtonColIndex = tmp.ColIndex;
                            pctbTag.RowIndex = tmp.RowIndex;
                            pctbTag.ColIndex = tmp.ColIndex;
                            XuLyDiChuyen();
                            await tcs1.Task;
                            MatrixButton[destButtonRowIndex][destButtonColIndex].BackColor = Color.Lime;
                            if (adjList[v][i] == 2804)
                            {
                                tcs2.SetResult(true);
                                MessageBox.Show("Đã tới đích", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                isRun = false;
                                return;
                            }
                        }
                    }
                }
                frmMain.instance.KetQua.Text += "\n";
                //writer.WriteLine();
            //}
            Tcs2.SetResult(true);
            isRun = false;
        }

        private string GetDirection(int preRowIndex, int preColIndex, int newRowIndex, int newColIndex)
        {
            if ((newRowIndex - 1 > preRowIndex || newColIndex - 1 > preColIndex) || (preRowIndex - 1 > newRowIndex || preColIndex - 1 > newColIndex))
            {
                return "teleport";
            }
            else
            {
                if (newRowIndex > preRowIndex)
                {
                    if (newColIndex < preColIndex)
                    {
                        return "leftbottom";
                    }

                    if (newColIndex > preColIndex)
                    {
                        return "rightbottom";
                    }
                    return "down";
                }

                if (newRowIndex < preRowIndex)
                {
                    if (newColIndex > preColIndex)
                    {
                        return "righttop";
                    }

                    if (newColIndex < preColIndex)
                    {
                        return "lefttop";
                    }
                    return "up";
                }

                if (newColIndex > preColIndex)
                {
                    if (newRowIndex > preRowIndex)
                    {
                        return "rightbottom";
                    }

                    if (newRowIndex < preRowIndex)
                    {
                        return "righttop";
                    }
                    return "right";
                }

                if (newColIndex < preColIndex)
                {
                    if (newRowIndex < preRowIndex)
                    {
                        return "lefttop";
                    }

                    if (newRowIndex > preRowIndex)
                    {
                        return "leftbottom";
                    }
                    return "left";
                }

                //if (newColIndex > preColIndex && newRowIndex > preRowIndex)
                //{
                //    return "rightbottom";
                //}

                //if (newRowIndex > preRowIndex && newColIndex < preColIndex)
                //{
                //    return "leftbottom";
                //}

                //if (newRowIndex < preRowIndex && newColIndex > preRowIndex)
                //{
                //    return "righttop";
                //}

                //if (newColIndex < preColIndex && newRowIndex < preRowIndex)
                //{
                //    return "lefttop";
                //}
            }

            return "";
        }

        public void CleanBoard()
        {
            _totalButtonSelect = 0;
            try
            {
                ManPctb.SendToBack();
            }
            catch (Exception e)
            {

            }
            for (int i = 0; i < MatrixButton.Count; i++)
            {
                for (int j = 0; j < MatrixButton[i].Count; j++)
                {
                    MatrixButton[i][j].BackColor = SystemColors.Control;
                    MatrixButton[i][j].UseVisualStyleBackColor = true;
                    MatrixButton[i][j].BackgroundImage = null;
                }
            }
            visited = new List<bool>();
            for (int i = 0; i < ConstantVar.COL_NUMBER * ConstantVar.ROW_NUMBER; i++)
            {
                visited.Add(false);
            }
            
            for (int i = 0; i < adjList_original.Count; i++)
            {
                for (int j = 0; j < adjList_original[i].Count; j++)
                {
                    adjList[i][j] = adjList_original[i][j];
                }
            }
        }

        private TaskCompletionSource<bool> tcs3;

        public async void testTraversal(string traversalType)
        {
            /*
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
                   Tag = new PictureBoxTag() { RowIndex = tagTmp.RowIndex, ColIndex = tagTmp.ColIndex},
                   BackgroundImage = Properties.Resources.man,
                   BackColor = Color.Transparent,
                   BorderStyle = BorderStyle.FixedSingle
               };
               BoardPanel.Controls.Add(ManPctb);
             */
            int totalNode = ConstantVar.COL_NUMBER * ConstantVar.ROW_NUMBER;
            int k = 0, z = 0;
            tcs3 = new TaskCompletionSource<bool>();
            for (int i = 0; i < totalNode; i++)
            {
                CleanBoard();
                if (z >= ConstantVar.COL_NUMBER)
                {
                    z = 0;
                    k++;
                }
                MatrixButton[k][z].BackgroundImage = Properties.Resources.placeholder;
                buttonTag tagTmp = (buttonTag)MatrixButton[k][z].Tag;
                tagTmp.ImageTag = 4;
                MatrixButton[k][z].Tag = tagTmp;
                ManPctb = new PictureBox()
                {
                    Width = 30,
                    Height = 30,
                    //Location = new Point(ConstantVar.BTNPANEL_WIDTH, ConstantVar.BTNPANEL_HEIGHT), // x y
                    Location = new Point(MatrixButton[k][z].Location.X + 5, MatrixButton[k][z].Location.Y + 5),
                    BackgroundImageLayout = ImageLayout.Stretch,
                    Tag = new PictureBoxTag() { RowIndex = tagTmp.RowIndex, ColIndex = tagTmp.ColIndex },
                    BackgroundImage = Properties.Resources.man,
                    BackColor = Color.Transparent,
                    BorderStyle = BorderStyle.FixedSingle
                };
                BoardPanel.Controls.Add(ManPctb);
                //dfs();
                if (traversalType == "dfs")
                {
                    dfs();
                }
                else
                {
                    bfs();
                }
                await Tcs2.Task;
                z++;
            }
            tcs3.SetResult(true);
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

        private void MoveObjectRightBottom(int speed)
        {
            ManPctb.Left += speed;
            manPctb.Top += speed;
        }

        private void MoveObjectRightTop(int speed)
        {
            ManPctb.Left += speed;
            manPctb.Top -= speed;
        }

        private void MoveObjectLeftBottom(int speed)
        {
            ManPctb.Left -= speed;
            manPctb.Top += speed;
        }

        private void MoveObjectLeftTop(int speed)
        {
            ManPctb.Left -= speed;
            manPctb.Top -= speed;
        }
    }
}

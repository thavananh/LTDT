using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTDT
{
    public partial class frmMain : Form
    {

        #region Properties

        private Board board;
        public static frmMain instance;
        private RichTextBox ketQua;
        //private RichTextBox maTranKe;
        private List<List<int>> _adjList;
        private ListView _lstAdjMatrix;


        public RichTextBox KetQua { get => ketQua; set => ketQua = value; }
        public ListView LstAdjMatrix { get => _lstAdjMatrix; set => _lstAdjMatrix = value; }

        //public RichTextBox MaTranKe { get => maTranKe; set => maTranKe = value; }

        #endregion

        public frmMain()
        {
            InitializeComponent();
            instance = this;
            this.KetQua = rtxKetQua;
            //this.MaTranKe = rtxtMaTranKe;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            board = new Board(gradientPanel1);
            board.drawBoardPanel();
            this.LstAdjMatrix = lstvMaTranKe;
            loadAdjMatrix();
        }

        public void loadAdjMatrix()
        {
            _adjList = new List<List<int>>(board.AdjList);
            lstvMaTranKe.Clear();
            lstvMaTranKe.Columns.Add("", 45);
            for (int i = 0; i < ConstantVar.COL_NUMBER * ConstantVar.ROW_NUMBER; i++)
            {
                lstvMaTranKe.Columns.Add("v" + i.ToString(), 45, HorizontalAlignment.Center);
            }

            int v = 0;
            foreach (var row in _adjList)
            {
                ListViewItem item = new ListViewItem("v" + v.ToString());
                for (int i = 0; i < row.Count; i++)
                {
                    item.SubItems.Add(row[i].ToString());
                }
                lstvMaTranKe.Items.Add(item);
                v++;
            }

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private TaskCompletionSource<bool> tcsLoadAdjMatrix;

        private async void btnRun_Click(object sender, EventArgs e)
        {
            tcsLoadAdjMatrix = new TaskCompletionSource<bool>();
            loadAdjMatrix();
            tcsLoadAdjMatrix.SetResult(true);
            await tcsLoadAdjMatrix.Task;
            btnClean.Enabled = false;
            btnTest.Enabled = false;
            btnRun.Enabled = false;
            
            if (rdoBFS.Checked)
            {
                board.bfs();
            }
            else if (rdoDFS.Checked)
            {
                board.dfs();
            }
            await board.Tcs2.Task;
            btnClean.Enabled = true;
            btnTest.Enabled = true;
            btnRun.Enabled = true;
        }
        private void btnXoaCoVaDich_Click(object sender, EventArgs e)
        {
            board.CleanBoard();
        }

        private async void btnTest_Click(object sender, EventArgs e)
        {
            tcsLoadAdjMatrix = new TaskCompletionSource<bool>();
            loadAdjMatrix();
            tcsLoadAdjMatrix.SetResult(true);
            await tcsLoadAdjMatrix.Task;
            btnRun.Enabled = false;
            btnClean.Enabled = false;
            if (rdoBFS.Checked)
            {
                board.testTraversal("bfs");
            }
            else if (rdoDFS.Checked)
            {
                board.testTraversal("dfs");
            }
            await board.Tcs3.Task;
            btnRun.Enabled = true;
            btnClean.Enabled = true;
        }
    }
}

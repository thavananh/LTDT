using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
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
        private RichTextBox maTranKe;
        private List<List<int>> _adjList;


        public RichTextBox KetQua { get => ketQua; set => ketQua = value; }
        public RichTextBox MaTranKe { get => maTranKe; set => maTranKe = value; }

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
            _adjList = new List<List<int>>(board.AdjList);
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

        private async void btnRun_Click(object sender, EventArgs e)
        {
            btnClean.Enabled = false;
            btnTest.Enabled = false;
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
        }
        private void btnXoaCoVaDich_Click(object sender, EventArgs e)
        {
            board.CleanBoard();
        }

        private async void btnTest_Click(object sender, EventArgs e)
        {
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

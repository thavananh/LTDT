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


        public RichTextBox KetQua { get => ketQua; set => ketQua = value; }
        public RichTextBox MaTranKe { get => maTranKe; set => maTranKe = value; }

        #endregion

        public frmMain()
        {
            InitializeComponent();
            instance = this;
            this.KetQua = rtxKetQua;
            this.MaTranKe = rtxtMaTranKe;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            board = new Board(gradientPanel1);
            board.drawBoardPanel();

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

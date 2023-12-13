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

        public RichTextBox KetQua { get => ketQua; set => ketQua = value; }

        #endregion

        public frmMain()
        {
            InitializeComponent();
            instance = this;
            this.KetQua = rtxKetQua;
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

        private void btnRun_Click(object sender, EventArgs e)
        {
            board.dfs();
        }
    }
}

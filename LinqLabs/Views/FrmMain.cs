using LinqLabs.作業;
using MyHomeWork;
using Starter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqLabs.Views
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnHW1_Click(object sender, EventArgs e)
        {
            (new Frm作業_1()).Show();
        }

        private void btnHW2_Click(object sender, EventArgs e)
        {
            (new Frm作業_2()).Show();
        }
        private void btnHW3_Click(object sender, EventArgs e)
        {
            (new Frm作業_3()).Show();
        }
        private void btnFrmHelloLinq_Click(object sender, EventArgs e)
        {
            (new FrmHelloLinq()).Show();
        }

        private void btnFrmLangForLINQ_Click(object sender, EventArgs e)
        {
            (new FrmLangForLINQ()).Show();

        }

        private void btnLINQInside_Click(object sender, EventArgs e)
        {
            (new FrmLINQ架構介紹_InsideLINQ()).Show();

        }

        private void btnFrmLINQ_To_XXX_Click(object sender, EventArgs e)
        {
            (new FrmLINQ_To_XXX()).Show();

        }

        private void btnFrmLinq_To_Entity_Click(object sender, EventArgs e)
        {
            (new FrmLinq_To_Entity()).Show();

        }

        
    }
}

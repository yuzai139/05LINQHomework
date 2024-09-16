using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHomeWork
{
    public partial class Frm作業_2 : Form
    {
        public Frm作業_2()
        {
            InitializeComponent();
            this.productPhotoTableAdapter1.Fill(this.adventureDataSet1.ProductPhoto);
            comboBox3.Items.Add(1998);
            comboBox3.Items.Add(2002);
            comboBox3.Items.Add(2003);
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            var q = from p in this.adventureDataSet1.ProductPhoto
                    orderby p.ModifiedDate
                    select p;

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var q = from p in this.adventureDataSet1.ProductPhoto
                    orderby p.ModifiedDate
                    where p.ModifiedDate >= dateTimePicker1.Value && p.ModifiedDate <= dateTimePicker2.Value
                    select p;

            this.dataGridView1.DataSource = q.ToList();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox3.Text))
            {
                int year = Convert.ToInt32(comboBox3.Text);
                var q = from p in this.adventureDataSet1.ProductPhoto
                        orderby p.ModifiedDate
                        where p.ModifiedDate.Year == year
                        select p;

                this.dataGridView1.DataSource = q.ToList();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string season = comboBox2.Text;
            int monthBegin = 0;
            int monthEnd = 0;

            switch(season)
                {
                case "第一季":
                    monthBegin = 1;
                    monthEnd = 3;
                    break;
                case "第二季":
                    monthBegin = 4;
                    monthEnd = 6;
                    break;
                case "第三季":
                    monthBegin = 7;
                    monthEnd = 9;
                    break;
                case "第四季":
                    monthBegin = 10;
                    monthEnd = 12;
                    break;
                default:
                    break;
            };

            var q = from p in this.adventureDataSet1.ProductPhoto
                    //orderby p.ModifiedDate
                    where p.ModifiedDate.Month >= monthBegin && p.ModifiedDate.Month <= monthEnd
                    select p;

            this.dataGridView1.DataSource = q.ToList();
            lblNumber.Text = $"符合筆數：{this.dataGridView1.RowCount.ToString()} 筆";
        }
    }
}

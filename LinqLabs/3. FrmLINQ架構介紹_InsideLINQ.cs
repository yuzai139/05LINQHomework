using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Starter
{
    public partial class FrmLINQ架構介紹_InsideLINQ : Form
    {
        public FrmLINQ架構介紹_InsideLINQ()
        {
            InitializeComponent();
            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);
        }

        private void btnArrayList_Click(object sender, EventArgs e)
        {
            System.Collections.ArrayList arrayList = new System.Collections.ArrayList();
            arrayList.Add(9);
            arrayList.Add(13);

            var q = from n in arrayList.Cast<int>()  //非泛型集合無法當做來源物件
                    where n >9
                    select n;
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var q = (from p in this.nwDataSet1.Products
                    where p.UnitPrice > 20
                    orderby p.UnitsInStock
                    select p).Take(5);

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnAggregation_Click(object sender, EventArgs e)
        {
            //when excute query
            //    1.foreach
            //    2.toXXX()
            //    3.Aggregation Sum()..

            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            this.listBox1.Items.Add(nums.Sum());
            this.listBox1.Items.Add(nums.Max());
            this.listBox1.Items.Add(nums.Min());
            this.listBox1.Items.Add(nums.Average());
            this.listBox1.Items.Add(nums.Count());

            //=====================================================================
            var q = this.nwDataSet1.Products.Where(us => us.UnitsInStock > 0).Select(us => new { us.UnitsInStock });
            this.listBox1.Items.Add(this.nwDataSet1.Products.Average(n=>n.UnitsInStock));
            this.listBox1.Items.Add(this.nwDataSet1.Products.Max(n => n.UnitPrice));

        }
    }
}
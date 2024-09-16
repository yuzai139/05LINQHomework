using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Starter
{
    public partial class FrmHelloLinq : Form
    {
        public FrmHelloLinq()
        {
            InitializeComponent();
        }

        private void btnArray_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();

            //    public interface IEnumerable<T>
            //    System.Collections.Generic 的成員

            //摘要: 
            //公開支援指定類型集合上簡單反覆運算的列舉值。

            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            foreach (int i in nums)
            {
                this.listBox1.Items.Add(i);
            }
            this.listBox1.SelectedIndex = 0;
            //=======================================
            System.Collections.IEnumerator en = nums.GetEnumerator();
            while (en.MoveNext())
                this.listBox1.Items.Add(en.Current);
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();

            List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int i in nums)
            {
                this.listBox1.Items.Add(i);
            }
            this.listBox1.SelectedIndex = 0;
            //=======================================
            List<int>.Enumerator en1 = nums.GetEnumerator();
            System.Collections.IEnumerator en2 = nums.GetEnumerator();
            while (en1.MoveNext())
                this.listBox1.Items.Add(en1.Current);
        }

        private void btnQArray_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            //Step 1. define data source object
            //Step 2. define query
            //Step 3. execute query

            ////1
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            ////2
            //IEnumerable<int> q = from n in nums where IsEven(n) select n;
            ////3
            //foreach (int n in q)
            //{
            //    this.listBox1.Items.Add(n);
            //}

            //====enumerable string =====================================
            //1
            //int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            //2
            IEnumerable<string> q = from n in nums where IsEven(n) select n.ToString();
            //3
            foreach (string n in q)
            {
                this.listBox1.Items.Add(n);
            }

            //=====point object========================================

            //1
            //int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            //2
            IEnumerable<Point> q1 = from n in nums where IsEven(n) select new Point (n,n*n);
            //3
            foreach (Point n in q1)
            {
                //this.listBox1.Items.Add((n.X, "," + n.Y));
                //this.listBox1.Items.Add((n.X, n.Y));
            }
            
            List<Point> list = q1.ToList(); //=foreach
            this.listBox1.Items.Add(q1);
            this.dataGridView1.DataSource = list;

            //====chart================================
            this.chart1.DataSource = list;
            this.chart1.Series[0].XValueMember = "X";
            this.chart1.Series[0].YValueMembers = "Y";
            this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        }

        public bool IsEven(int n)
        {
            //if (n % 2 == 0)
            //    return true;
            //else
            //    return false;
            return n % 2 == 0;
        }

        private void btnQString_Click(object sender, EventArgs e)
        {
            string[] name = { "Tony", "Betty", "Andy", "Kevin", "Cindy", "AMeow", "AHei" };
            IEnumerable<string> q = from s in name
                                    where s.Length > 4 && s.Contains("y")
                                    select s ;

            foreach (string s in q)
            {
                this.listBox1.Items.Add(s);
            }

            //List<string> list = q.ToList();
            //this.dataGridView1.DataSource = list;
            //this.listBox1.Items.Add(q);

            //=============================================
            IEnumerable<string> q1 = from s in name
                                    where s.Length > 4 && s.Contains("y")
                                    select s;

            foreach (string s in q1)
            {
                this.listBox1.Items.Add(s);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter1.Fill(this.nWthDataSet11.Products);

            var q = from p in nWthDataSet11.Products
                    where p.UnitPrice >30 && p.ProductName.StartsWith("Ch")
                    select p;

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ordersTableAdapter1.Fill(this.nWthDataSet11.Orders);
            var q = from d in nWthDataSet11.Orders
                    where d.OrderDate.Year.Equals(1997) && !d.IsShippedDateNull()
                    select d;

            this.dataGridView1.DataSource = q.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace Starter
{
    public partial class FrmLINQ_To_XXX : Form
    {
        public FrmLINQ_To_XXX()
        {
            InitializeComponent();
            this.ordersTableAdapter1.Fill(this.nwDataSet1.Orders);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //<key, 群組內型別>
            //IEnumerable<IGrouping<int, int>> q = from n in nums
            //group n by n % 2;
            IEnumerable<IGrouping<string, int>> q = from n in nums
                                                    group n by n % 2 == 0 ? "Even" : "Odd";

            this.dataGridView1.DataSource = q.ToList();

            //=======================================================
            //下面treeView的應用
            foreach (var group in q)
            {
                TreeNode node = this.treeView1.Nodes.Add(group.Key.ToString());
                foreach (var item in group)
                {
                    node.Nodes.Add(item.ToString());

                }
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //spilt->Apply->Combine
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 13 };
            //IEnumerable<IGrouping<string, int>> q = from n in nums
            var q = from n in nums
                    group n by n % 2 == 0 ? "Even" : "Odd" into g
                    select new { myKey = g.Key, myCount = g.Count(), myAvg = g.Average(), myGroup = g };

            this.dataGridView1.DataSource = q.ToList();

            //=======================================================
            foreach (var group in q)
            {
                TreeNode node = this.treeView1.Nodes.Add($"{group.myKey.ToString()} (有 {group.myCount} 個)");
                foreach (var item in group.myGroup)
                {
                    node.Nodes.Add(item.ToString());

                }
            }
            //==============================================
            this.chart1.DataSource = q.ToList();
            this.chart1.Series[0].XValueMember = "myKey";
            this.chart1.Series[0].YValueMembers = "myCount";
            this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;


            this.chart1.Series[1].XValueMember = "myKey";
            this.chart1.Series[1].YValueMembers = "myAvg";
            this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //spilt->Apply->Combine
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 13 };
            //IEnumerable<IGrouping<string, int>> q = from n in nums
            var q = from n in nums
                    group n by MyKey(n) into g
                    select new { myKey = g.Key, myCount = g.Count(), myAvg = g.Average(), myGroup = g };

            this.dataGridView1.DataSource = q.ToList();

            //=======================================================
            foreach (var group in q)
            {
                TreeNode node = this.treeView1.Nodes.Add($"{group.myKey.ToString()} (有 {group.myCount} 個)");
                foreach (var item in group.myGroup)
                {
                    node.Nodes.Add(item.ToString());

                }
            }
        }

        string MyKey(int n)
        {
            if (n < 5)
                return "Small";
            else if (n < 10)
                return "Medien";
            else
                return "Large";

        }

        private void button38_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            var q = from f in files
                    group f by f.Length into g
                    select new { g.Key, count = g.Count() };

            this.dataGridView1.DataSource = q.ToList();



        }

        private void button12_Click(object sender, EventArgs e)
        {
            var q = from o in this.nwDataSet1.Orders
                    group o by o.OrderDate.Year into g
                    select new { year = g.Key, count = g.Count(), Mygroup = g };
            this.dataGridView1.DataSource = q.ToList();

            foreach (var group in q)
            {
                TreeNode node = this.treeView1.Nodes.Add($"{group.year.ToString()} 有 {group.count} 筆");
                foreach (var item in group.Mygroup)
                {
                    node.Nodes.Add($"{item.OrderDate.ToString()} {item.OrderID.ToString()}");

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string s = $"A massive landslide in a Greenland fjord triggered a wave that “shook the Earth” for nine days.\r\nThe seismic signal last September was picked up by sensors all over the world, leading scientists to investigate where it had come from.The landslide - a mountainside of rock that collapsed and carried glacial ice with it - triggered a 200m wave.\r\nThat wave was then “trapped” in the narrow fjord - moving back and forth for nine days, generating the vibrations.";

            char[] chi = { ',', ' ', '.' };

            string[] words = s.Split(chi);

            var q = from w in words
                    where w != ""
                    group w by w.ToUpper() into g
                    select new { g.Key, count = g.Count() };

            this.dataGridView1.DataSource = q.ToList();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            //var q = from f in files
            //        where f.Extension == ".log"
            //        select f;

            var q = from f in files
                    let s = f.Extension
                    where s == ".log"
                    select f;

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int[] numarr1 = { 1, 2, 4, 5, 67, 2, 4 };
            int[] numarr2 = { 2, 4, 11, 111, 12 };

            IEnumerable<int> q;
            q = numarr1.Intersect(numarr2);
            q = numarr1.Union(numarr2);
            q = numarr1.Distinct();

            List<bool> list = new List<bool>();
            list.Add(numarr1.Any(x => x > 0));
            list.Add(numarr1.Any(x => x > 0));
            bool result = numarr1.Any(x => x > 0);
            result = numarr1.Contains(0);

            int n = numarr1.First();
            n = numarr2.ElementAtOrDefault(0);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);
            this.categoriesTableAdapter1.Fill(this.nwDataSet1.Categories);

            var q = from p in this.nwDataSet1.Products
                    group p by p.CategoryID into g
                    orderby g.Key ascending
                    select new { categoryID = g.Key, avg = Math.Round(g.Average(p => p.UnitPrice), 0) };

            var q1 = from c in this.nwDataSet1.Categories
                    join p in this.nwDataSet1.Products
                           on c.CategoryID equals p.CategoryID
                           group p by c.CategoryName into g
                           select new { categoryID = g.Key, avg = Math.Round(g.Average(p => p.UnitPrice), 0) };
                           //select new { c.CategoryID, c.CategoryName, p.ProductID, p.ProductName, p.UnitPrice };
            this.dataGridView1.DataSource = q.ToList();
            this.dataGridView2.DataSource = q1.ToList();
        }
    }
}

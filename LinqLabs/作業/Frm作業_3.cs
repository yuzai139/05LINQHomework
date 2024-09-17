using LinqLabs.EntityDataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqLabs.作業
{
    public partial class Frm作業_3 : Form
    {


        public class Student
        {
            public string Name { get; set; }
            public string Class { get; set; }
            public string Gender { get; set; }
            public int Chi { get; set; }
            public int Eng { get; set; }
            public int Math { get; set; }
        }
        private List<Student> _stuScores;
        public Frm作業_3()
        {
            InitializeComponent();
            _stuScores = new List<Student>()
                    {
                    new Student{ Name = "aaa", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                    new Student{ Name = "bbb", Class = "CS_102", Chi = 80, Eng = 80, Math = 100, Gender = "Male" },
                    new Student{ Name = "ccc", Class = "CS_101", Chi = 60, Eng = 50, Math = 75, Gender = "Female" },
                    new Student{ Name = "ddd", Class = "CS_102", Chi = 80, Eng = 70, Math = 85, Gender = "Female" },
                    new Student{ Name = "eee", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Female" },
                    new Student{ Name = "fff", Class = "CS_102", Chi = 80, Eng = 80, Math = 80, Gender = "Female" },
                    };
        }

        private void button36_Click(object sender, EventArgs e)
        {
            #region 搜尋 班級學生成績

            // 
            // 共幾個 學員成績 ?		
            //var q = from s in _stuScores
            //select s;
            var q = _stuScores.Select(s => _stuScores);
            MessageBox.Show($"{q.Count().ToString()} 位");



            // 找出 前面三個 的學員所有科目成績
            var q1 = from s in _stuScores
                     select s;

            //this.dataGridView1.DataSource = q1.Take(3).Skip(0).ToList();

            // 找出 後面兩個 的學員所有科目成績
            var q2 = from s in _stuScores
                     select s;

            //this.dataGridView2.DataSource = q1.Take(6).Skip(4).ToList();

            // 找出 Name 'aaa','bbb','ccc' 的學員國文英文科目成績
            //var q3 = from s in _stuScores
            //         where s.Name == "aaa" || s.Name == "bbb" || s.Name == "ccc"
            //         select new { Name = s.Name, 國文 = s.Chi, 英文 = s.Eng };

            var q3 = _stuScores.Select(s => new { Name = s.Name, 國文 = s.Chi, 英文 = s.Eng })
                .Where(s => s.Name == "aaa" || s.Name == "bbb" || s.Name == "ccc");
            this.dataGridView1.DataSource = q3.ToList();

            // 找出學員 'bbb' 的成績	                          
            var q4 = _stuScores.Select(s => new { Name = s.Name, 國文 = s.Chi, 英文 = s.Eng, 數學 = s.Math })
                .Where(s => s.Name == "bbb");
            this.dataGridView2.DataSource = q4.ToList();
            // 找出除了 'bbb' 學員的學員的所有成績 ('bbb' 退學)	
            var q5 = _stuScores.Select(s => new { Name = s.Name, 國文 = s.Chi, 英文 = s.Eng, 數學 = s.Math })
                .Where(s => s.Name != "bbb");
            this.dataGridView1.DataSource = q5.ToList();

            // 找出 'aaa', 'bbb' 'ccc' 學員 國文數學兩科 科目成績  |	
            var q6 = _stuScores.Select(s => new { Name = s.Name, 國文 = s.Chi, 數學 = s.Math })
                .Where(s => s.Name == "aaa" || s.Name == "bbb" || s.Name == "ccc");
            this.dataGridView2.DataSource = q6.ToList();
            // 數學不及格 ... 是誰 
            var q7 = _stuScores.Select(s => new { Name = s.Name, 數學 = s.Math })
                .Where(s => s.數學 < 60);
            this.dataGridView1.DataSource = q7.ToList();
            #endregion
        }

        private void button37_Click(object sender, EventArgs e)
        {
            //個人 sum, min, max, avg
            // 統計 每個學生個人成績 並排序
            var studentAnalysis = _stuScores.Select(s => new
            {
                s.Name,
                Sum = s.Chi + s.Eng + s.Math,
                Avg = Math.Round((decimal)((s.Chi + s.Eng + s.Math) / 3), 1),
                Max = new[] { s.Chi, s.Eng, s.Math }.Max(),
                Min = new[] { s.Chi, s.Eng, s.Math }.Min(),
            }).OrderBy(s => s.Name);

            dataGridView1.DataSource = studentAnalysis.ToList();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            // split=> 分成 三群 '待加強'(60~69) '佳'(70~89) '優良'(90~100)
            var q = from s in _stuScores
                    group s by Level((s.Chi + s.Eng + s.Math) / 3) into g
                    select new { 群 = g.Key, 數量 = g.Count() };

            dataGridView1.DataSource = q.ToList();

            // print 每一群是哪幾個 ? (每一群 sort by 分數 descending)
        }

        private string Level(int avg)
        {
            if (avg >= 60 && avg < 70)
                return "待加強";
            else if (avg >= 70 && avg < 90)
                return "佳";
            else
                return "優良";

        }


        private void button38_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            var q = from f in files
                    group f by FileSize(f.Length) into g
                    select new { size = g.Key, count = g.Count() };

            this.dataGridView1.DataSource = q.ToList();

            var q1 = from f in files
                     orderby f.Length descending
                     select new { fileName = f.Name, Size = f.Length, Category = FileSize(f.Length) };
            this.dataGridView2.DataSource = q1.ToList();
            //foreach (var group in q)
            //{
            //    TreeNode node = this.treeView1.Nodes.Add(group.ToString());
            //    foreach (var item in group.ToString())
            //    {
            //        node.Nodes.Add(item.ToString());

            //    }
            //}
        }

        string FileSize(double f)
        {
            double fnum = Convert.ToInt32(f);
            if (fnum < 100)
                return "small (file.Length<100)";
            else if (fnum < 10000)
                return "median(file.Length<1000)";
            else
                return "large(file.Length>1000)";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            var q = from f in files
                    group f by f.CreationTime.Year into g
                    select new { year = g.Key, count = g.Count() };

            var q1 = from f in files
                     select f;


            this.dataGridView1.DataSource = q.ToList();
            this.dataGridView2.DataSource = q1.ToList();
            foreach (var group in q)
            {
                TreeNode node = this.treeView1.Nodes.Add(group.year.ToString());
                foreach (var item in group.year.ToString())
                {
                    node.Nodes.Add(item.ToString());

                }
            }
        }
        NorthwindEntities _dbContext = new NorthwindEntities();
        private void button8_Click(object sender, EventArgs e)
        {
            var q = from p in _dbContext.Products.ToList()
                    group p by Price(p.UnitPrice) into g
                    select new { 分類 = g.Key, 數量 = g.Count(), myGroup = g };
            dataGridView1.DataSource = q.ToList();

            foreach (var group in q)
            {
                TreeNode node = this.treeView1.Nodes.Add($"{group.分類.ToString()} (有 {group.數量} 個)");
                foreach (var item in group.myGroup)
                {
                    node.Nodes.Add($"Order: {item.ProductID} Date: {item.ProductName}");
                }
            }

            //var q1 = from p in _dbContext.Products.ToList()
            //         orderby p.UnitPrice descending
            //        select new {p.ProductName,p.UnitPrice,分類=Price(p.UnitPrice) };
            //dataGridView2.DataSource = q1.ToList();
        }

        public string Price(decimal? price)
        {
            //price = Convert.ToInt32(price);
            if (price <= 15)
                return "低價商品";
            else if (price > 25 && price < 75)
                return "中價商品";
            else
                return "高價商品";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var q = from o in _dbContext.Orders.ToList()
                    group o by o.OrderDate.Value.Year into g
                    select new { 年 = g.Key, 數量 = g.Count(), myGroup = g };
            dataGridView1.DataSource = q.ToList();

            foreach (var group in q)
            {
                TreeNode node = this.treeView1.Nodes.Add($"{group.年.ToString()} (有 {group.數量} 個)");
                foreach (var item in group.myGroup)
                {
                    node.Nodes.Add($"Order: {item.OrderID} Date: {item.OrderDate}");
                }
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            // IQueryable 尚未跟DB取得資料單純組語句
            // .ToList 把語法轉成SQL語句跟DB撈資料 已撈回記憶體

            var orderByYearMonth = _dbContext.Orders
                     .Where(x => x.OrderDate.HasValue)
                     .GroupBy(x => new { x.OrderDate.Value.Year, x.OrderDate.Value.Month })
                     .Select(x => new { year = x.Key.Year, month = x.Key.Month, Count = x.Count() })
                     .OrderBy(x => x.year)
                     .ThenBy(x => x.month)
                     .ToList();

            //var aa1 = _dbContext.Orders.Where(x => x.OrderDate.Value.AddDays(1) >= new DateTime(1990, 5, 9)).ToList();

            var q = (from o in _dbContext.Orders.ToList()
                     group o by new { o.OrderDate.Value.Year, o.OrderDate.Value.Month } into g
                     select new { 年 = g.Key.Year, 月 = g.Key.Month, 數量 = g.Count(), myGroup = g })
                    .OrderBy(x => x.年)
                    .ThenBy(x => x.月)
                    .ToList();

            dataGridView1.DataSource = q.ToList();
            //var a = from m in _dbContext.Orders.ToList()
            //        group m by m.OrderDate.Value.Month into h
            //        orderby h.Key
            //        select new { 月 = h.Key, 數量 = h.Count(), myGroup1 = h };



            //dataGridView2.DataSource = a.ToList();
            //寫兩套第二份無法年區分

            foreach (var group in q)
            {
                TreeNode node = this.treeView1.Nodes.Add($"{group.年}年 {group.月}月 (有 {group.數量} 個)");
                foreach (var item in group.myGroup)
                node.Nodes.Add($"Order: {item.OrderID} Date: {item.OrderDate}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var q = from o in _dbContext.Order_Details.ToList()
            //        select new { 訂單 = o.OrderID, 總銷售金額 = Convert.ToInt32(o.UnitPrice) * discount(o.Quantity * o.Discount) * o.Quantity };
            //dataGridView1.DataSource = q.ToList();
            var total = _dbContext.Order_Details.ToList()
                .GroupBy(x => new { x.OrderID, x.UnitPrice, x.Quantity, x.Discount })
                .Select(x => new { orderID = x.Key.OrderID, money = Convert.ToInt32(x.Key.UnitPrice) * x.Key.Quantity * discount(x.Key.Discount), group = x })
                ;

            dataGridView1.DataSource = total.ToList();
            //foreach (var item in total)
            //{
            //    count = count +item.group.;
            //}
            //MessageBox.Show("");
            //===================================================
            var q = /*(from x in _dbContext.Order_Details
                     orderby x.ProductID
                     select new
                     {
                         x.Product.ProductName,
                         x.Quantity,
                         x.UnitPrice,
                         //總額 = x.UnitPrice * x.Quantity,
                         x
                     })*/
                      _dbContext.Order_Details
                     .GroupBy(n => new { n.OrderID })
                     .Select(n => new { n.Key.OrderID, total = n.Sum(y => y.Quantity * y.UnitPrice) })
                     .ToList();


            //SelectMany對陣列、集合
            List<ICollection<Order_Detail>> a1 = _dbContext.Products.Select(x => x.Order_Details).ToList();
            List<Order_Detail> a2 = _dbContext.Products.SelectMany(x => x.Order_Details).ToList();

            var products = a2
                .GroupBy(data => data.Product.ProductName)
                .Select(x => new { x.Key, totoal = x.Sum(y => y.Quantity * y.UnitPrice) })
                .OrderBy(x => x.Key)
            .ToList();

            var a3 = _dbContext.Order_Details
                            .GroupBy(x => x.Product.ProductName)
                            .Select(x => new { x.Key, totoal = x.Sum(y => y.Quantity * y.UnitPrice) })
                            .OrderBy(x => x.Key)
                            .ToList();

            IList<string> tsst = new List<string> { "A1", "B2" };
            var aa11 = tsst.SelectMany(x => x);


            List<List<string>> test1 = new List<List<string>> {
                                       new List<string> { "A1" },
                                       new List<string> { "B2" } };
            List<string> test3 = test1.SelectMany(x => x).ToList();

            //foreach(var p in q)
            //{
            //    TreeNode treeNode = treeView1.Nodes.Add(p.Key.ProductName);
            //}
            dataGridView1.DataSource = q.ToList();

        }
        float discount(float d)
        {
            if (d == 0)
                return 1;
            else
                return d;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            var q = from p in _dbContext.Products.ToList()
                    orderby p.UnitPrice descending
                    select new { Name = p.ProductName, Price = p.UnitPrice, Category = p.Category.CategoryName };
            dataGridView1.DataSource = q.Take(5).ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var q = from p in _dbContext.Products.ToList()
                    where p.UnitPrice > 300
                    select new { Name = p.ProductName, Price = p.UnitPrice, Category = p.Category.CategoryName };
            dataGridView1.DataSource = q.ToList();
            if (q.Count() == 0)
                MessageBox.Show("No product is higher than $300");
        }
    }
}

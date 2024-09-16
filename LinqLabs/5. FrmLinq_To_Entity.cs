using LinqLabs.EntityDataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Starter
{
    public partial class FrmLinq_To_Entity : Form
    {
        public FrmLinq_To_Entity()
        {
            InitializeComponent();
            //this._dbContext.Database.Log = Console.Write; //查看背後執行的sql指令，輸出視窗
        }

        NorthwindEntities _dbContext = new NorthwindEntities();
        private void button1_Click(object sender, EventArgs e)
        {

            var q = from p in _dbContext.Products
                    where p.UnitPrice>30
                    select p;
            dataGridView1.DataSource = q.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= this._dbContext.Categories.First().Products.ToList();

            MessageBox.Show(this._dbContext.Products.First().Category.CategoryName);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            var q = from p in _dbContext.Products
                    orderby p.UnitsInStock , p.ProductID ascending
                    
                    select p;

            dataGridView1.DataSource = q.ToList();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            var q1 = from c in this._dbContext.Categories
                     join p in this._dbContext.Products
                            on c.CategoryID equals p.CategoryID
                     select new { c.CategoryID, c.CategoryName, p.ProductID, p.ProductName, p.UnitPrice };
            dataGridView1.DataSource = q1.ToList();
            //join
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //有導覽屬性，不用join就可有same效果
            var q = from p in this._dbContext.Products
                    select new { p.CategoryID, p.Category.CategoryName, p.ProductID, p.ProductName, p.UnitPrice };

            this.dataGridView2.DataSource = q.ToList();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            var q = from c in this._dbContext.Categories
                    from p in c.Products
                    select new { c.CategoryID, c.CategoryName, p.ProductID, p.ProductName, p.UnitPrice };

            this.dataGridView3.DataSource = q.ToList();
            //double from
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var q = from p in this._dbContext.Products//.ToList() //.AsEnumerable
                    group p by p.Category.CategoryName into g
                    select new { CategoryName = g.Key, AvgPrice = $"{g.Average(p => p.UnitPrice):c2}" };

            //toList()=轉型 聽不懂，總之tryParse就可以用了
            //我用Math.Round()需要強制轉型，但就不用toList()
            dataGridView1.DataSource = q.ToList();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //bool? b = null;
            //b.Value

            var q = from o in this._dbContext.Orders
                    group o by o.OrderDate.Value.Year into g
                    select new {year=g.Key,count=g.Count()};
            dataGridView1.DataSource= q.ToList();
        }

        private void button55_Click(object sender, EventArgs e)
        {
            Product product = new Product() {ProductName = "Tony's phone",Discontinued = true };
            this._dbContext.Products.Add(product);

            this._dbContext.SaveChanges();
        }

    }
}

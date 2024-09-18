using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHomeWork
{
    public partial class Frm作業_1 : Form
    {
        private int _comboBox = 0; //下拉年

        private int _txtPage = 0;  //每頁筆數
        private int _take = 0;    //取幾筆
        private int _skip = 0;     //省略幾筆
        private int _count = 0;    //計次

        public Frm作業_1()
        {
            InitializeComponent();
            comboBox1.Text = "1996";
            _comboBox = Convert.ToInt32(comboBox1.Text);
            _txtPage = Convert.ToInt32(txtPage.Text);
        }
        private void Frm作業_1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add(1996);
            comboBox1.Items.Add(1997);
            comboBox1.Items.Add(1998);
            this.order_DetailsTableAdapter2.Fill(this.nwDataSet1.Order_Details);
            this.ordersTableAdapter2.Fill(this.nwDataSet1.Orders);
            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);

        }

        private void button14_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            //files[0].Extension

            var log = from logFile in files
                      where logFile.Extension == ".log"
                      select logFile;

            List<FileInfo> list = log.ToList();
            this.dataGridView2.DataSource = list;
            lblDetails.Text = "FileInfo[].Log  擋";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            var log = from logFile in files
                      where logFile.CreationTime.Year == 2022
                      select logFile;

            List<FileInfo> list = log.ToList();
            this.dataGridView2.DataSource = list;
            lblDetails.Text = "FileInfo[] - 2017 Created - oerder ";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"D:\iSPAN\010LINQ\錄影");

            System.IO.FileInfo[] files = dir.GetFiles();

            //files[0].Extension

            var log = from logFile in files
                      where logFile.Length > 2000
                      select logFile;

            List<FileInfo> list = log.ToList();
            this.dataGridView2.DataSource = list;
            lblDetails.Text = "FileInfo[] - 大檔案";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            showAllOrder();
            lblDetails.Text = "";
        }

        private void showAllOrder()
        {            
            var q = from o in this.nwDataSet1.Orders
                    select o;

            this.dataGridView1.DataSource = q.ToList();
            lblMaster.Text = "All 訂單";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _take = Convert.ToInt32(txtPage.Text);
            showPartPage();
        }
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int cellValue = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            var q = from orderDe in this.nwDataSet1.Order_Details
                    where orderDe.OrderID == cellValue
                    select orderDe;

            this.dataGridView2.DataSource = q.ToList();
        }

        private void showPartPage()
        {
            _comboBox = Convert.ToInt32(comboBox1.Text);
            var q = from o in this.nwDataSet1.Orders
                    where o.OrderDate.Year == _comboBox
                    select o;

            this.dataGridView1.DataSource = q.ToList();//Take(takePg).Skip(skipPg).

            var q1 = from od in this.nwDataSet1.Order_Details
                     join o in this.nwDataSet1.Orders
                    on od.OrderID equals o.OrderID
                    where o.OrderDate.Year == _comboBox
                    select od;

            this.dataGridView2.DataSource = q1.ToList();
            lblMaster.Text = $"{comboBox1.Text}年訂單";
            lblDetails.Text = "訂單明細";

        }

        

        private void button12_Click(object sender, EventArgs e)//上
        {
            if (_skip > 0)
            {
                _txtPage = Convert.ToInt32(txtPage.Text);
                _count--;
                _take = _txtPage * _count;
                _skip = _txtPage * (_count - 1);
                var q = from p in this.nwDataSet1.Products
                        select p;


                this.dataGridView1.DataSource = q.Take(_take).Skip(_skip).ToList();
                //==================================
                lblCount.Text = "count: " + _count.ToString();
                lblSkip.Text = "skip: " + _skip.ToString();
                lblTake.Text = "take: " + _take.ToString();
            }
        }
        private void button13_Click(object sender, EventArgs e)//下
        {
            if (this.dataGridView1.RowCount>=_txtPage)
            {
                _txtPage = Convert.ToInt32(txtPage.Text);
                _count++;
                _take = _txtPage * _count;
                _skip = _txtPage * (_count - 1);
                var q = from p in this.nwDataSet1.Products
                        select p;

                this.dataGridView1.DataSource = q.Take(_take).Skip(_skip).ToList();
                //==================================
                //lblCount.Text = "count: " + _count.ToString();
                //lblSkip.Text = "skip: " + _skip.ToString();
                //lblTake.Text = "take: " + _take.ToString();
            }
        }
        

        private void txtPage_TabStopChanged(object sender, EventArgs e)
        {
            _txtPage = Convert.ToInt32(txtPage.Text);
            _count = 0;
            _take = 0;
            _skip = 0;

        }

        private void btnShowProduct_Click(object sender, EventArgs e)
        {
            ShowProduct();
            dataGridView2.DataSource = null;
            lblMaster.Text = $"訂單(一次{_txtPage}筆)";
            lblDetails.Text = "";
        }

        private void ShowProduct()
        {
            _txtPage = Convert.ToInt32(txtPage.Text);
            _count=1;
            _take = _txtPage * _count;
            _skip = _txtPage * (_count - 1);
            var q = from p in this.nwDataSet1.Products
                    select p;


            this.dataGridView1.DataSource = q.Take(_take).Skip(_skip).ToList();
        }
    }
}

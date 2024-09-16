using LinqLabs;
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
    public partial class FrmLangForLINQ : Form
    {
        public FrmLangForLINQ()
        {
            InitializeComponent();

        }

        private void btnSwapIntStr_Click(object sender, EventArgs e)
        {
            int n1 = 100;
            int n2 = 200;
            MessageBox.Show($"n1={n1},n2={n2}");  //交換前
            Swap(ref n1, ref n2);
            //(int a, int b) = Swap1(n1, n2);
            MessageBox.Show($"n1={n1},n2={n2}");  //交換後

            //string s1 = "";
            //string s2 = "";
            //MessageBox.Show($"n1={n1},n2={n2}");  //交換前
            //Swap(ref s1, ref s2);
            ////(int a, int b) = Swap1(n1, n2);
            //MessageBox.Show($"n1={n1},n2={n2}");  //交換後
        }

        private void Swap(ref int n1, ref int n2)
        {
            int a = 0;
            a = n1;
            n1 = n2;
            n2 = a;
        }
        //(int, int) Swap1(int n1, int n2)  //(int,int)是為了return的格式,缺了一個return會出錯
        //{                                 //元組tuple
        //    int c = 0;
        //    c = n1;
        //    n1 = n2;
        //    n2 = c;
        //    return (n1, n2);
        //}
        private void SwapAnyType<T>(ref T n1, ref T n2)
        {
            T a;
            a = n1;
            n1 = n2;
            n2 = a;
        }
        private void btnSwapAnytype_Click(object sender, EventArgs e)
        {
            int n1 = 100;
            int n2 = 200;
            MessageBox.Show($"n1={n1},n2={n2}");  //交換前
            SwapAnyType<int>(ref n1, ref n2);
            //(int a, int b) = Swap1(n1, n2);
            MessageBox.Show($"n1={n1},n2={n2}");  //交換後

            string s1 = "123";
            string s2 = "456";
            MessageBox.Show($"n1={s1},n2={s2}");  //交換前
            SwapAnyType<string>(ref s1, ref s2);
            //(int a, int b) = Swap1(n1, n2);
            MessageBox.Show($"n1={s1},n2={s2}");  //交換後
        }

        private void btnDelegate_Click(object sender, EventArgs e)
        {
            //控制buttonX
            //==C#2.0===具名方法==========
            //this.buttonX.Click += new EventHandler();
            this.buttonX.Click += ButtonX_Click;
            this.buttonX.Click += aaa;
            //====匿名方法===============
            this.buttonX.Click += delegate (object sender1, EventArgs e1)
            {
                MessageBox.Show("匿名方法");
            };
            //====C#3.0 Lambda 運算式 =>goes to=================
            this.buttonX.Click += (object sender1, EventArgs e1) =>
            {
                MessageBox.Show("匿名方法");
            };

        }
        private void aaa(object sender, EventArgs e)
        {
            MessageBox.Show("aaa");
        }
        private void ButtonX_Click(object sender, EventArgs e)
        {
            MessageBox.Show("btnX_Click");
        }

        /*
            step1: create delegate class    
            step2: create delegate object
            step3: invoke method / call method
            
        */

        delegate bool MyDelegate(int n);
        private void button1_Click(object sender, EventArgs e)
        {
            //具名方法
            //====一般寫法用方法=================================
            bool result;
            result = test(10);
            MessageBox.Show("是否大於5？\nResult: " + result);
            //====綁delegate===================================
            MyDelegate delegateObj = new MyDelegate(test);
            result = delegateObj(9);
            MessageBox.Show("是否大於5？\nResult: " + result);
            //====綁複數delegate===================================
            delegateObj = IsEven;
            //result = delegateObj.(10);
            result = delegateObj.Invoke(10); //Invoke可寫可不寫，我猜是為了容易辨識
            MessageBox.Show("是否奇數？\nResult: " + result);
            //==========================================
            delegateObj = IsOdd;
            //result = delegateObj.(10);
            result = delegateObj.Invoke(10);
            MessageBox.Show("是否偶數？\nResult: " + result);

            //======C#2.0匿名方法===========================================================
            delegateObj = delegate (int n)
            {
                return n > 5;
            };
            result = delegateObj.Invoke(10);
            MessageBox.Show("是否大於5？\nResult: " + result);
            //=====C#3.0 Lambda======================================================
            delegateObj = n => n > 5;
            result = delegateObj.Invoke(10);
            MessageBox.Show("是否大於5？\nResult: " + result);
        }
        bool IsEven(int n)
        {
            return (n % 2 == 0);
        }
        bool IsOdd(int n)
        {
            return (n % 2 == 1);
        }
        bool test(int n)
        {
            return n > 5;
        }
        bool test2(int n1, int n2)
        {
            return true;
            //for test delegate signature
        }
        List<int> MyWhere(int[] nums, MyDelegate delegateObj)
        {
            List<int> list = new List<int>();
            foreach (int n in nums)
            {
                if (delegateObj(n))
                    list.Add(n);
            }
            return list;
        }
        private void btnMyWhere_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            MyWhere(nums, test);
            //MyWhere(nums, test2); for test delegate signature

            List<int> largeList = MyWhere(nums, n => n > 5);
            List<int> oddList = MyWhere(nums, IsOdd);
            List<int> evenList = MyWhere(nums, IsEven);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            //IEnumerable<int> q = from n in nums where IsEven(n) select n;

            IEnumerable<int> q = MyWhere(nums, IsOdd);
            IEnumerable<int> qq = nums.Where<int>(n => n > 6); //"<>"可不寫，它會自動判別

            foreach (int n in q)
            {
                this.listBox1.Items.Add(n);
            }

            string[] str = { "Tony", "Betty", "Ahe" };
            IEnumerable<string> q1 = str.Where(n => n.Length > 3);
            foreach (string s in q1)
            {
                this.listBox2.Items.Add(s);
            }
        }
        IEnumerable<int> MyIterator(int[] nums, MyDelegate delegateObj)
        {
            foreach (int n in nums)
            {
                if (delegateObj(n))
                    yield return n;
            }

        }
        private void button13_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            IEnumerable<int> q = MyIterator(nums, n => n > 5);

            foreach (int n in q)
            {
                this.listBox1.Items.Add(n);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool b;
            b = true;
            b = false;
            //====================
            bool? result;
            result = true;
            result = false;
            result = null;
        }

        private void button45_Click(object sender, EventArgs e)
        {
            int n1 = 100;
            int n2 = 200;

            var s = "Tony";
            s = s.ToLower();

            var p = new Point(n1, n2);
            MessageBox.Show(p.X + " , " + p.Y);
        }

        private void button41_Click(object sender, EventArgs e)
        {
            //Point pt = new Point(1,2);

            //====tradition=================
            MyPoint pt1 = new MyPoint();
            pt1.P1 = 100;
            pt1.P2 = 200;

            //建構子方法
            List<MyPoint> list = new List<MyPoint>();
            list.Add(pt1);
            list.Add(new MyPoint(10));
            list.Add(new MyPoint(20, 20));

            //物件初始化
            list.Add(new MyPoint { P1 = 10, P2 = 20, field1 = 100, field2 = 200 });

            this.dataGridView1.DataSource = list;
            //===========================================================================
            List<MyPoint> list2 = new List<MyPoint>
            {
                new MyPoint { P1 = 10 ,P2 = 20 },
                new MyPoint { P1 = 20, P2 = 30 },
                new MyPoint { P1 = 30, P2 = 40 },
                new MyPoint { P1 = 40, P2 = 50 },
            };

            this.dataGridView2.DataSource = list2;
        }

        private void button43_Click(object sender, EventArgs e)
        {
            //匿名型別only can get, can't set.
            var pt1 = new { P1 = 10, P2 = 20, P3 = 30 };
            var pt2 = new { P1 = "十"/*, P2 = "二十", P3 = "三十"*/ };
            var pt3 = new { X = 30, Y = 45 };

            this.listBox1.Items.Add(pt1.GetType());
            this.listBox1.Items.Add(pt2.GetType());
            this.listBox1.Items.Add(pt3.GetType());

            //============================================================

            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            //IEnumerable<int>不適用，一般式
            //var q = from n in nums
            //        where n > 5
            //        select new { N = n, square = n * n, cube = n * n * n };
            
            //寫成方法式
            var q = nums.Where(n => n > 5).Select(n=> new {N = n, square = n * n, cube = n * n * n});


            this.dataGridView1.DataSource = q.ToList();

            //=========================================================

            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);

            var q1 = from p in nwDataSet1.Products
                    where p.UnitPrice > 50
                    select new
                    {
                        ID = p.ProductID,
                        品名 = p.ProductName,
                        價錢 = p.UnitPrice,
                        庫存 = p.UnitsInStock,
                        總價 = Math.Round(p.UnitPrice * p.UnitsInStock,0)
                    };
            this.dataGridView2.DataSource = q1.ToList();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            string s = "Betty";

            MessageBox.Show($"count = {s.wordCount()} \nBetty : char[ 3 ] = ' {s.Chars(3)} '");
            MyStringExtend.wordCount("tttt");
        }
    }
}
class MyPoint //object initializer
{
    //constrctor
    public MyPoint()
    {

    }
    public MyPoint(int p1)
    {
        this.P1 = p1;
    }
    public MyPoint(int p1, int p2)
    {
        this.P1 = p1;
        this.P2 = p2;
    }
    //Property
    private int _p1;
    public int P1
    {
        get { return _p1; }
        set { _p1 = value; }
    }
    public int P2 { get; set; }

    //class variable
    public int field1 = 900;
    public int field2 = 800;
}
public static class MyStringExtend //Extend method
{
    public static int wordCount(this string s)
    {
        return s.Length;
    }

    public static char Chars(this string s,int index)
    {
        return s[index];
    }

}



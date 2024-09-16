using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            var q4 = _stuScores.Select(s => new { Name = s.Name, 國文 = s.Chi, 英文 = s.Eng,數學 = s.Math })
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
                .Where(s => s.數學<60);
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
                Avg = Math.Round((decimal)((s.Chi + s.Eng + s.Math) / 3),1),
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
                    select new { 群 = g.Key,數量=g.Count()};

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

        private void button10_Click(object sender, EventArgs e)
        {
           
        }

        private void button38_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            var q = from f in files
                    group f by FileSize(f.Length) into g
                    select new { size = g.Key, count = g.Count() };

            this.dataGridView1.DataSource = q.ToList();
            

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
            else if (fnum < 1000)
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

    }
}

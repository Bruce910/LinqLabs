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
        List<Student> student = new List<Student>
            {
            new Student { Name = "aaa", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
            new Student { Name = "bbb", Class = "CS_102", Chi = 80, Eng = 80, Math = 100, Gender = "Male" },
            new Student { Name = "ccc", Class = "CS_101", Chi = 60, Eng = 50, Math = 75, Gender = "Female" },
            new Student { Name = "ddd", Class = "CS_102", Chi = 32, Eng = 70, Math = 85, Gender = "Female" },
            new Student { Name = "eee", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Female" },
            new Student { Name = "fff", Class = "CS_102", Chi = 44, Eng = 23, Math = 80, Gender = "Female" },
            new Student { Name = "ggg", Class = "CS_101", Chi = 80, Eng =90, Math = 50,Gender="Male" },
            new Student { Name = "hhh", Class = "CS_102",Chi = 23, Eng=80, Math =30,Gender="Male" },
            new Student { Name = "hhh", Class = "CS_102", Chi = 23, Eng = 80, Math = 30, Gender = "Male" },
            new Student { Name = "iii", Class = "CS_101", Chi = 45, Eng = 67, Math = 78, Gender = "Female" },
            new Student { Name = "jjj", Class = "CS_102", Chi = 85, Eng = 90, Math = 56, Gender = "Male" },
            new Student { Name = "kkk", Class = "CS_101", Chi = 70, Eng = 75, Math = 60, Gender = "Female" },
            new Student { Name = "lll", Class = "CS_102", Chi = 55, Eng = 60, Math = 50, Gender = "Male" },
            new Student { Name = "mmm", Class = "CS_101", Chi = 90, Eng = 95, Math = 85, Gender = "Female" },
            new Student { Name = "nnn", Class = "CS_102", Chi = 65, Eng = 70, Math = 75, Gender = "Male" },
            new Student { Name = "ooo", Class = "CS_101", Chi = 50, Eng = 55, Math = 40, Gender = "Female" },
            new Student { Name = "ppp", Class = "CS_102", Chi = 78, Eng = 80, Math = 88, Gender = "Male" },
            new Student { Name = "qqq", Class = "CS_101", Chi = 60, Eng = 65, Math = 70, Gender = "Female" }
            };
        public Frm作業_3()
        {
            InitializeComponent();
          


            dataGridView1.DataSource = student;

            IEnumerable<string> a = (from n in student
                                     select n.Class.ToString()).Distinct();


            //IEnumerable<string> a = student.Select(n => n.Class).Distinct();

            foreach (string b in a)
            {
                comboBox1.Items.Add(b);
            }

            comboBox1.SelectedIndexChanged += (s, e) =>
            {
                comboBox2.Text = "";
                comboBox2.Items.Clear();
                IEnumerable<string> c = student.Where(n => n.Class == comboBox1.Text).Select(n => n.Name);

                foreach (string d in c)
                {
                    comboBox2.Items.Add(d);
                };
            };


            //hint
            //students_scores = new List<Student>()
            //                             {
            //                                new Student{ Name = "aaa", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
            //                                new Student{ Name = "bbb", Class = "CS_102", Chi = 80, Eng = 80, Math = 100, Gender = "Male" },
            //                                new Student{ Name = "ccc", Class = "CS_101", Chi = 60, Eng = 50, Math = 75, Gender = "Female" },
            //                                new Student{ Name = "ddd", Class = "CS_102", Chi = 80, Eng = 70, Math = 85, Gender = "Female" },
            //                                new Student{ Name = "eee", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Female" },
            //                                new Student{ Name = "fff", Class = "CS_102", Chi = 80, Eng = 80, Math = 80, Gender = "Female" },

            //                              };
        }

        private void button36_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            #region 搜尋 班級學生成績

            // 
            // 共幾個 學員成績 ?						

            // 找出 前面三個 的學員所有科目成績					
            // 找出 後面兩個 的學員所有科目成績					

            // 找出 Name 'aaa','bbb','ccc' 的學員國文英文科目成績						

            // 找出學員 'bbb' 的成績	                          

            // 找出除了 'bbb' 學員的學員的所有成績 ('bbb' 退學)	

            // 找出 'aaa', 'bbb' 'ccc' 學員 國文數學兩科 科目成績  |				
            // 數學不及格 ... 是誰 
            #endregion

            var x = from n in student
                    where n.Name == comboBox2.Text && n.Class == comboBox1.Text
                    select new { n.Chi, n.Eng, n.Math };

            dataGridView1.DataSource = x.ToList();

        }

        private void button37_Click(object sender, EventArgs e)
        {
            //個人 sum, min, max, avg
            // 統計 每個學生個人成績 並排序

            var f = from n in student
                    select new
                    {
                        n.Class,
                        n.Name,
                        成績總和 = n.Chi + n.Eng + n.Math,
                        最低分 = Math.Min(n.Chi, Math.Min(n.Eng, n.Math)),
                        最高分 = Math.Max(n.Chi, Math.Max(n.Eng, n.Math)),
                        平均成績 = (n.Chi + n.Eng + n.Math) / 3
                    };
            dataGridView1.DataSource = f.ToList();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f = from n in student
                    orderby n.Chi + n.Eng + n.Math
                    select new
                    {
                        n.Class,
                        n.Name,
                        成績總和 = n.Chi + n.Eng + n.Math
                    };
            dataGridView1.DataSource= f.ToList();
        }
        public class Student
        {
            public string Name { get; set; }
            public string Class { get; set; }
            public int Chi { get; set; }
            public int Eng { get; set; }
            public int Math { get; set; }
            public string Gender { get; set; }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            // split=> 分成 三群 '待加強'(60~69) '佳'(70~89) '優良'(90~100) 
            var 評價順序 = new Dictionary<string, int>
            {
                { "優良", 1 },
                { "普通", 2 },
                { "爛死", 3 }
            };
            var a = from n in student
                    group n by Idiot(n.Math) into g
                    select  new { 評價 = g.Key, 學生數量 = g.Count(), 姓名 = string.Join(", ", g.Select(x => x.Name)) };


            // print 每一群是哪幾個 ? (每一群 sort by 分數 descending)
            var sortedA = a.OrderBy(x => 評價順序[x.評價]);
            foreach (var i in sortedA)
            {
                TreeNode tn = this.treeView1.Nodes.Add(i.評價);
                var names = i.姓名.Split(new[] { ", " }, StringSplitOptions.None);
                foreach (var name in names)
                {
                    tn.Nodes.Add(name);
                }
            }
            dataGridView1.DataSource = a.ToList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = from n in student
                    orderby (n.Chi + n.Eng + n.Math) / 3 descending
                    select new
                    {                        
                        n.Class,
                        n.Name,
                        平均成績 = (n.Chi + n.Eng + n.Math) / 3
                    };
            dataGridView1.DataSource = f.ToList();
        }

        string Idiot(int n)
        {
            if (n > 90)
            {
                return "優良";
            }
            else if (n > 70 && n < 89)
            {
                return "普通";
            }
            else
            {
                return "爛死";
            }
        }
        string FilesBigOrNot(int n)
        {
            if (n > 30000)
            {
                return "大檔案";
            }
            else if (n > 10000 && n < 30000)
            {
                return "一般大小檔案";
            }
            else
            {
                return "迷你檔案";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            treeView1.Nodes.Clear();
            this.dataGridView2.DataSource = null;

            var 評價順序 = new Dictionary<string, int>
            {
                { "大檔案",1 },
                { "一般大小檔案",2},
                { "迷你檔案",3}
            };


            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();
            var q=from f in files
                  group f by FilesBigOrNot((int)f.Length) into g                  
                  select new { 分類 = g.Key, 檔案數量 = g.Count(), 檔案名稱 = string.Join("、 ", g.Select(x => x.Name)) };
            dataGridView2.DataSource = q.ToList();

            var sortedQ=q.OrderBy(x => 評價順序[x.分類]);
            foreach(var i in sortedQ)
            {
                TreeNode tree = this.treeView1.Nodes.Add(i.分類);
                string[] names = i.檔案名稱.Split(new[] { "、" },StringSplitOptions.None);
                foreach(string name in names)
                {
                    this.treeView1.Nodes.Add(name);
                }
            }
                    
        }

        string FileYears(int n)
        {
            if (n >=2024)
            {
                return "近期檔案";
            }
            else if (n >2022 && n < 2024)
            {
                return "中古時期檔案";
            }
            else
            {
                return "史前時期檔案";
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            this.dataGridView2.DataSource = null;

            var 評價順序= new Dictionary<string, int>
            {
                { "近代檔案",1 },
                { "中古時期檔案",2},
                { "史前時期檔案",3}
            };

            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();
            var q = from f in files
                    group f by FileYears(Convert.ToInt32(f.CreationTime.Year)) into g
                    select new { 年代 = g.Key, 檔案數量 = g.Count(), 檔案名稱 = string.Join("、 ", g.Select(x => x.Name)) };
            dataGridView2.DataSource = q.ToList();

            var sortedQ = q.OrderBy(x => x.年代);
            foreach (var i in sortedQ)
            {
                TreeNode tree = this.treeView1.Nodes.Add(i.年代);
                string[] names = i.檔案名稱.Split(new[] { "、" }, StringSplitOptions.None);
                foreach (var name in names)
                {
                    this.treeView1.Nodes.Add(name);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            var a = from n in student
                    where n.Name != "bbb"
                    select n;

            dataGridView1.DataSource = a.ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            var a = from n in student
                    where n.Math < 60
                    select new { 姓名=n.Name };
            dataGridView1.DataSource = a.ToList();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            var a = from n in student
                    where n.Name== "aaa" || n.Name == "bbb" || n.Name == "ccc"
                    select new { 姓名 = n.Name,國文=n.Chi,數學=n.Math };

            dataGridView1.DataSource = a.ToList();
        }
        NorthwindEntities dbContext = new NorthwindEntities();
        string PriceGood(decimal? n)
        {
            if (n >= 1000)
            {
                return "高價產品";
            }
            else if (n > 2022 && n < 2024)
            {
                return "中價產品";
            }
            else
            {
                return "便宜貨";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            var q =from n in this.dbContext.Products.ToList()
                   group n by n.UnitPrice.GetValueOrDefault() into g
                   select new { 單價 = g.Key, 產品數量 = g.Count(), 產品名稱 = string.Join("、 ", g.Select(x => x.ProductName)) };

            this.dataGridView2.DataSource = q.ToList();
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }
    }
}

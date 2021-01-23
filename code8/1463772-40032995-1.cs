    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace DataGridViewPanel
    {
        public partial class Form1 : Form
        {
            private dataBase Db = new dataBase();
            private List<dataBase> DbList = new List<dataBase>();
            private DataSet Ds = new DataSet();
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                //createColumns();
                createColumns();
                fillDataGrid();
                //populate datagrid by setting datasource
                dataGridView1.DataSource = Ds.Tables[0];
            }
            private void AddRow()
            {
                dataBase db = new dataBase();
                db.one = DateTime.Now.Day.ToString();
                db.two = DateTime.Now.Month.ToString();
                db.three = DateTime.Now.Year.ToString();
                db.four = DateTime.Now.Hour.ToString();
                db.five = DateTime.Now.Minute.ToString();
                db.six = DateTime.Now.Second.ToString();
                db.seven = DateTime.Now.Millisecond.ToString();
                DbList.Add(db);
                fillDataGrid();
            }
            private void fillDataGrid()
            {
                for (int i = DbList.Count - 1; i > Ds.Tables[0].Rows.Count - 1; i--)
                {
                    Ds.Tables[0].Rows.Add();
                    int loop = 0;
                    foreach (string valueStr in DbList[i])
                    {
                        int end = Ds.Tables[0].Rows.Count - 1;
                        Ds.Tables[0].Rows[end][loop] = valueStr;
                        loop++;
                    }
                }
            }
            private void createColumns()
            {
                this.Invoke(new MethodInvoker(delegate
                    {
                        Ds.Tables.Add(new DataTable());
                        Ds.Tables[0].Columns.Add("one");
                        Ds.Tables[0].Columns.Add("two");
                        Ds.Tables[0].Columns.Add("three");
                        Ds.Tables[0].Columns.Add("four");
                        Ds.Tables[0].Columns.Add("five");
                        Ds.Tables[0].Columns.Add("six");
                        Ds.Tables[0].Columns.Add("seven");
                        Ds.Tables[0].Columns.Add("eight");
                        Ds.Tables[0].Columns.Add("nine");
                        Ds.Tables[0].Columns.Add("ten");
                    }));
            }
            private void button1_Click(object sender, EventArgs e)
            {
                //populate datagridview1 with an empty List
                DbList = new List<dataBase>();
                Ds.Clear();
            }
            private void button2_Click(object sender, EventArgs e)
            {
                //populate datagridview1 with List after adding a new row to the List
                //Ds.Tables[0].Rows.Add(Db);
                AddRow();
            }
        }
        public class dataBase : IEnumerable<string>
        {
            public string one { get; set; }
            public string two { get; set; }
            public string three { get; set; }
            public string four { get; set; }
            public string five { get; set; }
            public string six { get; set; }
            public string seven { get; set; }
            public string eight { get; set; }
            public string nine { get; set; }
            public string ten { get; set; }
            public IEnumerator<string> GetEnumerator()
            {
                yield return one;
                yield return two;
                yield return three;
                yield return four;
                yield return five;
                yield return six;
                yield return seven;
                yield return eight;
                yield return nine;
                yield return ten;
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }
    }

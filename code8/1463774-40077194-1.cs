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
            private BindingList<dataBase> DbList = new BindingList<dataBase>();
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                //populate datagrid by setting datasource
                dataGridView1.DataSource = DbList;
            }
            private void AddRow()
            {
                //create a new set of data
                dataBase db = new dataBase();
                db.one = DateTime.Now.Day.ToString();
                db.two = DateTime.Now.Month.ToString();
                db.three = DateTime.Now.Year.ToString();
                db.four = DateTime.Now.Hour.ToString();
                db.five = DateTime.Now.Minute.ToString();
                db.six = DateTime.Now.Second.ToString();
                db.seven = DateTime.Now.Millisecond.ToString();
                
                //add data to the list
                DbList.Add(db);
            }
            private void removeRow()
            {
                //check if cells are selected
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    //loop while rows are selected
                    while (dataGridView1.SelectedCells.Count > 0)
                    {
                        //remove selecteed cell 0
                        DbList.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);
                    }
                }
            }
            private void button1_Click(object sender, EventArgs e)
            {
                //populate datagridview1 with an empty List
                DbList.Clear();
            }
            private void button2_Click(object sender, EventArgs e)
            {
                //add a new row to the List
                AddRow();
            }
            private void button3_Click(object sender, EventArgs e)
            {
                //remove a row from the list
                removeRow();
            }
        }
        //custom class with string enumeration
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

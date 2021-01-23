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
            private List<dataBase> headList = new List<dataBase>();
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                fillDataGrid();
            }
            private void fillDataGrid()
            {
                //add ten rows to the List
                for (int i = 0; i < 10; i++)
                {
                    DbList.Add(Db);
                }
                //add one row to the List to populate headers
                headList.Add(Db);
                //populate datagrid by setting datasource
                dataGridView1.DataSource = DbList;
                dataGridView2.DataSource = headList;
                resizeDataGrids();
            }
            private void resizeDataGrids()
            {
                //resize the datagrids so the panels enable the scrollbars when required
                int width = 0;
                int height = 0;
                foreach (DataGridViewColumn col in dataGridView1.Columns) width += col.Width;
                foreach (DataGridViewRow row in dataGridView1.Rows) height += row.Height;
                dataGridView1.Size = new Size(width, height);
                width = 0;
                height = 0;
                foreach (DataGridViewColumn col in dataGridView2.Columns) width += col.Width;
                foreach (DataGridViewRow row in dataGridView2.Rows) height += row.Height;
                dataGridView2.Size = new Size(width, height);
                //bring panel1 to front
                panel1.BringToFront();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                //populate datagridview1 with an empty List
                DbList = new List<dataBase>();
                DbList.Add(Db);
                dataGridView1.DataSource = DbList;
                resizeDataGrids();
            }
            private void button2_Click(object sender, EventArgs e)
            {
                //populate datagridview1 with List after adding a new row to the List
                DbList = (List<dataBase>)dataGridView1.DataSource;
                dataGridView1.DataSource = null;
                DbList.Add(Db);
                dataGridView1.DataSource = DbList;
                resizeDataGrids();
            }
            void panel1_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
            {
                //Handle horizontal scroll
                if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.HorizontalScroll)
                {
                    panel2.HorizontalScroll.Value = panel1.HorizontalScroll.Value;
                    panel1.BringToFront();
                }
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

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace Projekt
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            DataTable table = new DataTable();
            DataTable table2 = new DataTable();
            private void Form1_Load(object sender, EventArgs e)
            {
                table.Columns.Add("Process", typeof(int));
                table.Columns.Add("Arrival Time", typeof(string));
                table.Columns.Add("Burst Time", typeof(string));
                table.Columns.Add("Piority", typeof(int));
                table.Rows.Add("1");
                table.Rows.Add("2");
                table.Rows.Add("3");
                table.Rows.Add("4");
                dataGridView1.DataSource = table;
            }
            private void button1_Click(object sender, EventArgs e)
            {
                Random rand = new Random();
                table.Rows[0][0] = rand.Next(5, 30);
                table.Rows[1][0] = rand.Next(5, 30);
                table.Rows[2][0] = rand.Next(5, 30);
                table.Rows[3][0] = rand.Next(5, 30);
                table.Rows[0][3] = rand.Next(5, 30);
                table.Rows[1][3] = rand.Next(5, 30);
                table.Rows[2][3] = rand.Next(5, 30);
                table.Rows[3][3] = rand.Next(5, 30);
                dataGridView1 = null;  //to force update
                dataGridView1.DataSource = table;
            }
            private void FCFS_Click(object sender, EventArgs e)
            {
                table2 = table.Clone();
                dataGridView2.DataSource = table2;
            }
        }
    }

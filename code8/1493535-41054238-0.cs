    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace WindowsFormsApplication10
    {
        public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader file = new System.IO.StreamReader("C:\\Users\\terrazo\\Desktop\\test1.txt");
            string[] columnnames = file.ReadLine().Split(' ');
            DataTable dt = new DataTable();
            foreach (string c in columnnames)
            {
                if (c != "")
                {
                    dt.Columns.Add(c);
                }
            }
            string newline;
            while ((newline = file.ReadLine()) != null)
            {
                DataRow dr = dt.NewRow();
                string[] values = newline.Split(' ');
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i] != "")
                    {
                        dr[i] = values[i];
                    }
                }
                dt.Rows.Add(dr);
            }
            file.Close();
            dataGridView1.DataSource = dt;
        }
    }
    }

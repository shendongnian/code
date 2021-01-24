    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            const string FILENAME = @"c:\temp\test.txt";
            public Form1()
            {
                InitializeComponent();
                DataTable dt = new DataTable();
                dt.Columns.Add("Col A", typeof(string));
                dt.Columns.Add("Col B", typeof(string));
                dt.Columns.Add("Col C", typeof(string));
                dt.Columns.Add("Col D", typeof(string));
                dt.Columns.Add("Col E", typeof(string));
                StreamReader reader = new StreamReader(FILENAME);
                string inputLine = "";
                while((inputLine = reader.ReadLine()) != null)
                {
                    string[] inputArray = inputLine.Split(new char[] { ' ' });
                    dt.Rows.Add(inputArray);
                }
                dataGridView1.DataSource = dt;
            }
        }
    }

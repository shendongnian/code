    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    namespace stackkcw
    {
        public partial class Form1 : Form
        {
            public TcpClient client;
            private DataGridView datgdStock;
            private TextBox lablUpdates;
            private TextBox lablTime;
            private int countOfData;
            DataTable dt = new DataTable();
            public Form1()
            {
                InitializeComponent();
                init_dataGridView();
            }
            const int NUM_COLUMNS = 5;
            DataGridViewColumn[] columns;
            DataGridViewCheckBoxColumn checkColumn;
            List<String> columnsHeaderName;
            // init method
            private void init_dataGridView()
            {
                dt.Columns.Add("File path", typeof(string));
                dt.Columns.Add("Sampling", typeof(decimal));
                dt.Columns.Add("Start Date", typeof(DateTime));
                dt.Columns.Add("End Date", typeof(DateTime));
                dt.Columns.Add("Select", typeof(Boolean));
                dt.Rows.Add(new object[] { "c:\\", 123.45, DateTime.Parse("1/1/2017"), DateTime.Parse("1/2/2017"), true });
                dt.Rows.Add(new object[] { "c:\\", 123.46, DateTime.Parse("1/8/2017"), DateTime.Parse("1/9/2017"), false });
                dt.Rows.Add(new object[] { "c:\\", 123.47, DateTime.Parse("1/15/2017"), DateTime.Parse("1/16/2017"), true });
                dt.Rows.Add(new object[] { "c:\\", 123.48, DateTime.Parse("1/22/2017"), DateTime.Parse("1/23/2017"), false });
                dt.Rows.Add(new object[] { "c:\\", 123.49, DateTime.Parse("1/29/2017"), DateTime.Parse("1/30/2017"), true });
                dataGridView1.DataSource = dt;
            }
        }
    }

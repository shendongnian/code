    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    namespace WinFormQ
    {
        public partial class Q1 : Form
        {
            public Q1()
            {
                InitializeComponent();
            }
            BindingSource bs;
            private void Q1_Load(object sender, EventArgs e)
            {
                // SqlConnection conn = new SqlConnection(@"Data Source=xxxxx;Initial Catalog=xxxxx;Integrated Security=True;");
                // conn.Open();
                // SqlCommand sc = new SqlCommand("  SELECT id, customername+' - '+cast(inserted as varchar(19)) as targ FROM bf where customername>'a' order by customername asc, inserted desc ", conn);
                // SqlDataReader reader;
                // 
                // reader = sc.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("targ", typeof(string));
                // dt.Load(reader);
                dt.Rows.Add("1", "Targ-1");  // example code - remove
                dt.Rows.Add("2", "Targ-2");  // example code - remove
                dt.Rows.Add("3", "Targ-3");  // example code - remove
                dt.Rows.Add("4", "Targ-4");  // example code - remove
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "targ";
                comboBox1.DataSource = dt;
                // var select = "SELECT [id],[CustomerName[email],[Capital] FROM baf order by id desc";
                // var c = new SqlConnection("Data Source=xxxxxx;Initial Catalog=xxxxx;Integrated Security=True;");  Your Connection String here
                // var dataAdapter = new SqlDataAdapter(select, c);
                // var commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataSet ds = new DataSet();
                DataTable bf = new DataTable("BF");
                bf.Columns.Add("id", typeof(string));  // example code - remove
                bf.Columns.Add("CustomerName", typeof(string));  // example code - remove
                bf.Columns.Add("Email", typeof(string));  // example code - remove
                bf.Columns.Add("Capital", typeof(string));  // example code - remove
                
                ds.Tables.Add(bf);
                bs = new BindingSource(ds, "BF");
                // dataAdapter.Fill(bf);
                bf.Rows.Add("1", "Customer-1", "Email-1", "Capital-1");  // example code - remove
                bf.Rows.Add("1", "Customer-2", "Email-2", "Capital-1");  // example code - remove
                bf.Rows.Add("2", "Customer-3", "Email-3", "Capital-2");  // example code - remove
                bf.Rows.Add("3", "Customer-4", "Email-4", "Capital-3");  // example code - remove
                bf.Rows.Add("3", "Customer-5", "Email-5", "Capital-3");  // example code - remove
                bf.Rows.Add("3", "Customer-6", "Email-6", "Capital-3");  // example code - remove
                bf.Rows.Add("4", "Customer-7", "Email-7", "Capital-4");  // example code - remove
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = bs;
                this.comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
            }
            void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (comboBox1.Text == "Remove filter")
                {
                    bs.RemoveFilter();
                }
                else if (comboBox1.SelectedValue == null)
                {
                    bs.RemoveFilter();
                }
                else
                {
                    bs.Filter = "id = " + comboBox1.SelectedValue;
                }
            }
        }
    }

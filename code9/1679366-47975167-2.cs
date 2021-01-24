    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Data.SqlServerCe;
    using System.Data.OleDb;
    
    namespace Practice
    {
        public partial class Form1 : Form
        {
            private DataTable dt;
            public Form1()
            {
                InitializeComponent();
                fetchData();
            }
            private void fetchData()
            {
                DataTable retdt = new DataTable();
                SqlCeConnection con = null;
                SqlCeDataAdapter da = null;
                try
                {
                    con = new SqlCeConnection(@"Data Source=c:\users\mswami\documents\visual studio 2010\Projects\Practice\Practice\practice.sdf");
                    da = new SqlCeDataAdapter("select uid,amount from TestTable", con);
                    da.Fill(retdt);
                    dt = retdt.Copy();
                    DGPractice.DataSource = retdt.DefaultView;
                    DGPractice.BindingContext = this.BindingContext;
                }
                catch (Exception exce)
                {
                    MessageBox.Show(exce.Message);
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (maskedTextBox1.Text.Length > 0)
                {
                    if (dt.Select("amount=" + maskedTextBox1.Text).Length == 0)
                    {
                        DataRow drow = dt.NewRow();
                        drow[0] = 5;
                        drow[1] = Math.Round(Double.Parse(maskedTextBox1.Text),2);
                        dt.Rows.Add(drow);
                        dt.AcceptChanges();
    
                        DGPractice.DataSource = null;
                        DGPractice.DataSource = dt.DefaultView;
                        DGPractice.BindingContext = this.BindingContext;
                    }
                    else
                    {
                        MessageBox.Show("Duplicate amount");
                    }
                }
            }
        }
    
    }

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Data.OleDb;
    using Excel = Microsoft.Office.Interop.Excel;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Configuration;
    using System.Data.SqlClient;
    
    namespace WindowsFormsApplication6
    {
        public partial class Form1 : Form
        {
    
    
            private DataTable table;
            private DAL dal;
            protected void Form_Load(object sender, EventArgs e)
    
            {
                dal = new DAL();
                table = dal.GetData();
                dataGridView1.DataSource = table;
            }
    
            public Form1()
            {
                InitializeComponent();
            }
    private void button5_Click(object sender, EventArgs e)
            {
                dal.UpdateData(table);
            }
    
            class DAL //data access layer
            {
                string connString = @"Server=EXCEL-PC\EXCELDEVELOPER;Database=AdventureWorksLT2012;Trusted_Connection=True;";
                SqlDataAdapter da;
                SqlCommandBuilder builder;
                DataTable table;
                SqlConnection conn;
                public DataTable GetData()
                {
                    table = new DataTable("dataGridView1");
                    conn = new SqlConnection(connString);
                    da = new SqlDataAdapter();
                    da.SelectCommand = new SqlCommand(@"SELECT * FROM [SalesLT].[Product]", conn);
                    builder = new SqlCommandBuilder(da);
                    da.Fill(table);
                    return table;
                }
                public void UpdateData(DataTable table)
                {
                    if (da != null && builder != null)
                    {
                        da.Update(table);
                    }
                }
            }
    
        }
    }

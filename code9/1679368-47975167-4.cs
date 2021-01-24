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
            private DataTable retdt;
            SqlCeDataAdapter da;
            SqlCeCommandBuilder cbuild;
            SqlCeConnection con;
            public Form1()
            {
                InitializeComponent();
                fetchData();
            }
            private void fetchData()
            {
                retdt = new DataTable();
                SqlCeConnection con = null;
                try
                {
                    con = new SqlCeConnection(@"Data Source=c:\users\mswami\documents\visual studio 2010\Projects\Practice\Practice\practice.sdf");
                    da = new SqlCeDataAdapter();
                    da.SelectCommand = new SqlCeCommand("select uid,amount from TestTable", con);
                    cbuild = new SqlCeCommandBuilder(da);
                    con.Open();
                    da.Fill(retdt);
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
                    if (retdt.Select("amount=" + maskedTextBox1.Text).Length == 0)
                    {
                        DataRow drow = retdt.NewRow();
                        // drow[0] left blank as it is primary key column with auto increment value
                        drow[1] = Math.Round(Double.Parse(maskedTextBox1.Text),2);
                        retdt.Rows.Add(drow);
                        
                        //Update changes into database table
                        // First process deletes.  
                        da.Update(retdt.Select(null, null, DataViewRowState.Deleted));
    
                        // Next process updates.  
                        da.Update(retdt.Select(null, null,
                          DataViewRowState.ModifiedCurrent));
    
                        // Finally, process inserts.  
                        da.Update(retdt.Select(null, null, DataViewRowState.Added));
    
                        DGPractice.DataSource = null;
                        DGPractice.DataSource = retdt.DefaultView;
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

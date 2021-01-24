    using System;
    using System.Data;
    using System.Windows.Forms;
    
    namespace DataGridViewToXML_43053387
    {
        public partial class Form1 : Form
        {
            //DataSet theDataSet;
            public Form1()
            {
                InitializeComponent();
                InsertDgvIntoForm();
                ExportDgvToXML();
            }
    
            private void InsertDgvIntoForm()
            {
                //create a data set
                DataSet ds = new DataSet();
                //create a data table for the data set
                DataTable dt = new DataTable();
                //create some columns for the datatable
                DataColumn dc = new DataColumn("ItemName");
                DataColumn dc2 = new DataColumn("ItemValue");
                DataColumn dc3 = new DataColumn("Blah");
                DataColumn dc4 = new DataColumn("Bleh");
                //add the columns to the datatable
                dt.Columns.Add(dc);
                dt.Columns.Add(dc2);
                dt.Columns.Add(dc3);
                dt.Columns.Add(dc4);
    
                //create 5 rows of irrelevant information
                for (int i = 0; i < 5; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["ItemName"] = "Item" + i + "Name";
                    dr["ItemValue"] = "Item" + i + "Value";
                    dr["Blah"] = "Item" + i + "Blah";
                    dr["Bleh"] = "Item" + i + "Bleh";
                    dt.Rows.Add(dr);
                }
                //add the datatable to the datasource
                ds.Tables.Add(dt);
                //just because it looks better on my screen
                dataGridView1.AutoSize = true;
                //make this data the datasource of our gridview
                dataGridView1.DataSource = ds.Tables[0];
    
            }
    
            private void ExportDgvToXML()
            {
                DataTable dt = (DataTable)dataGridView1.DataSource;
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "XML|*.xml";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        dt.WriteXml(sfd.FileName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
        }
    }

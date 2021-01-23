    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel; 
    
    namespace WindowsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                    System.Data.OleDb.OleDbConnection MyConnection ;
                    System.Data.DataSet DtSet ;
                    System.Data.OleDb.OleDbDataAdapter MyCommand ;
                    MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='c:\\csharp.net-informations.xls';Extended Properties=Excel 8.0;");
                    MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
                    MyCommand.TableMappings.Add("Table", "TestTable");
                    DtSet = new System.Data.DataSet();
                    MyCommand.Fill(DtSet);
                    dataGridView1.DataSource = DtSet.Tables[0];
                    MyConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show (ex.ToString());
                }
            }
       }
    }

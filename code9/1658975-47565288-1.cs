    using System;
    using System.Windows.Forms;
    using System.Data;
    using System.Data.SqlClient;
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
                SqlConnection cnn ;
                string connectionString = null;
                string sql = null;
    
                connectionString = "data source=servername;initial catalog=databasename;user id=username;password=password;";
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                sql = "SELECT * FROM Product";
                SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
                DataSet ds = new DataSet();
                dscmd.Fill(ds);
    
                dataGridView1.DataSource = ds.Tables[0];
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                Excel.Application xlApp ;
                Excel.Workbook xlWorkBook ;
                Excel.Worksheet xlWorkSheet ;
                object misValue = System.Reflection.Missing.Value;
    
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                int i = 0;
                int j = 0; 
    
                for (i = 0; i <= dataGridView1.RowCount  - 1; i++)
                {
                    for (j = 0; j <= dataGridView1.ColumnCount  - 1; j++)
                    {
                        DataGridViewCell cell = dataGridView1[j, i];
                        xlWorkSheet.Cells[i + 1, j + 1] = cell.Value;
                    }
                }
    
                xlWorkBook.SaveAs("csharp.net-informations.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
    
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
    
                MessageBox.Show("Excel file created , you can find the file c:\\csharp.net-informations.xls");
            }
    
            private void releaseObject(object obj)
            {
                try
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                    obj = null;
                }
                catch (Exception ex)
                {
                    obj = null;
                    MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
                }
                finally
                {
                    GC.Collect();
                }
            }
    
        }
    }

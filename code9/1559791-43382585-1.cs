    private void button4_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void BindGrid()
    {
        string path = "C:\\Users\\Excel\\Desktop\\Coding\\DOT.NET\\Samples C#\\Export DataGridView to SQL Server Table\\Import_List.xls";
        string jet = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0", path);
        OleDbConnection conn = new OleDbConnection(jet);
        OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        dataGridView1.DataSource = dt;
        BulkUpload();
    }
        protected void BulkUpload()
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            string connection = "Data Source=excel-pc;Initial Catalog=Northwind.MDF;Trusted_Connection=True;";
            
            using (var conn = new SqlConnection(connection))
            {
                List<string> errors = new List<string>();
                try{
                    conn.Open();
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                    {
                        bulkCopy.ColumnMappings.Add(0, "Fname");
                        bulkCopy.ColumnMappings.Add(1, "Lname");
                        bulkCopy.ColumnMappings.Add(2, "Age");
     
                        bulkCopy.BatchSize = 10000;
                        bulkCopy.DestinationTableName = "Import_List";
                        bulkCopy.WriteToServer(dt.CreateDataReader());
                    }
                }
                catch (Exception e)
                {
                    errors.Add("Error: " + e.ToString());
                }
                finally
                {
                    conn.Dispose();
                }
            }
        }

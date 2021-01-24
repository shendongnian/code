    private void button3_Click(object sender, EventArgs e)
    {
        System.Data.OleDb.OleDbConnection ExcelConnection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Excel\\Desktop\\Coding\\DOT.NET\\Samples C#\\Export DataGridView to SQL Server Table\\Import_List.xls;Extended Properties=Excel 8.0;");
        ExcelConnection.Open();
        string expr = "SELECT * FROM [Sheet1$]";
        OleDbCommand objCmdSelect = new OleDbCommand(expr, ExcelConnection);
        OleDbDataReader objDR = null;
        SqlConnection SQLconn = new SqlConnection();
        string ConnString = "Data Source=Excel-PC;Initial Catalog=Northwind.MDF;Trusted_Connection=True;";
        SQLconn.ConnectionString = ConnString;
        SQLconn.Open();
        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(SQLconn))
        {
            bulkCopy.DestinationTableName = "tblTest";
            try
            {
                objDR = objCmdSelect.ExecuteReader();
                bulkCopy.WriteToServer(objDR);
                ExcelConnection.Close();
                //objDR.Close()
                SQLconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }

    protected void ButtonAdd_Click1(object sender, EventArgs e)
     {
        if (ViewState["CurrentTable"] != null)
            {
            DataTable dt = (DataTable)ViewState["CurrentTable"];       
            if (dt.Rows.Count > 0)
            {
                string consString = ConfigurationManager.ConnectionStrings["gridconnection"]
                  .ConnectionString;
                using (SqlConnection connection = new SqlConnection(consString))
                {
                    connection.Open();
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                    {
                        //foreach (DataColumn c in dt.Columns)
                        //   // bulkCopy.ColumnMappings.Add(c.Column1, c.Column2, c.Column3);
    
                        bulkCopy.DestinationTableName = "GridExcel";
                        //bulkCopy.ColumnMappings.Add(Column1, c.Column2, c.Column3);
                        SqlBulkCopyColumnMapping Column =
                            new SqlBulkCopyColumnMapping("Column1", "Column1");
                        bulkCopy.ColumnMappings.Add(Column);
                        SqlBulkCopyColumnMapping Column2nd =
                           new SqlBulkCopyColumnMapping("Column2", "Column2");
                        bulkCopy.ColumnMappings.Add(Column2nd);
                        SqlBulkCopyColumnMapping Column3rd =
                           new SqlBulkCopyColumnMapping("Column3", "Column3");
                        bulkCopy.ColumnMappings.Add(Column3rd);
                        try
                        {
                            bulkCopy.WriteToServer(dt);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }
     }

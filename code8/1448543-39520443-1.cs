     //This first method is psuedoCode to explain how to create your datatable. You need to do it in the way that makes sense for you.
     public DataTable createDataTable(){
        List<string> excludedColumns = new List<string>();
        excludedColumns.Add("FieldToExclude");
        //...
        DataTable dt = new DataTable();
        foreach(string col in getColumns(myTable)){
             if(!excludedColumns.Contains(name)){
             DataColumn dC = new DataColumn(name,type);
             DataTable.Add(dC);
         }
         return dt;
    }
            
    
     public List<string> getColumns(string tableName)
        {
            List<string> ret = new List<string>();
            using (SqlConnection conn = getConn())
            {
                conn.Open();
                using (SqlCommand com = conn.CreateCommand())
                {
                    com.CommandText = "select column_Name from information_schema.COLUMNS where table_name = @tab";
                    com.Parameters.AddWithValue("@tab", tableName);
                    SqlDataReader read = com.ExecuteReader();
                    While(read.Read()){
                    ret.Add(Convert.ToString(read[0]);
                }
                conn.Close();
            }
            return ret;
        }
     //Now, you have a DataTable that has all the columns you want to insert. Map them yourself in code by adding to the appropriate column in your datatable.
     public bool isCopyInProgess = false;//not necessary - just part of my code
        public  void saveDataTable(string tableName, DataTable table)
        {
            using (SqlConnection conn = getConn())
            {
                conn.Open();
                using (var bulkCopy = new SqlBulkCopy(conn))//, SqlBulkCopyOptions.KeepIdentity))//un-comment if you want to use your own identity column
                {
                    // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match, just pass in which datatable name matches the SQL column name in Column Mappings
                    foreach (DataColumn col in table.Columns)
                    {
                        //Console.WriteLine("mapping " + col.ColumnName+" ("+does_Column_Exist(col.ColumnName,"Item").ToString()+")");
                        bulkCopy.ColumnMappings.Add(col.ColumnName, "["+col.ColumnName+"]");
                       // Console.WriteLine("ok\n");
                    }
                    bulkCopy.BulkCopyTimeout = 8000;
                    bulkCopy.DestinationTableName = tableName;
                    bulkCopy.BatchSize = 10000;
                    bulkCopy.EnableStreaming = true;
                    //bulkCopy.SqlRowsCopied += BulkCopy_SqlRowsCopied;
                    //bulkCopy.NotifyAfter = 10000;
                    isCopyInProgess = true;
                   bulkCopy.WriteToServer(table);
                }
                conn.Close();
            }
        }

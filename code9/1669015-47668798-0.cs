            var insertQuery = "INSERT INTO [Table1] IN 'C:\Data\Users.mdf' SELECT * FROM [Table1]";
            ExecuteQuery(insertQuery, connProd);
            var count = 10;
            do
            {
                var selectQuery = "SELECT TOP 1 * FROM " + tableProdCopy;
                var dtTopRowData = GetQueryData(selectQuery, connOther);
                if (dtTopRowData != null && dtTopRowData.Rows.Count > 0)
                {
                    count = 0;
                    break;
                }
                System.Threading.Thread.Sleep(2000);
                count = count - 1;
            } while (count > 0);
            
            private DataTable GetQueryData(string query, OleDbConnection conn)
            {
                using (OleDbCommand cmdOutput = new OleDbCommand(query, conn))
                {
                    using (OleDbDataAdapter adapterOutput = new OleDbDataAdapter(cmdOutput))
                    {
                        var dtOutput = new DataTable();
    
                        adapterOutput.Fill(dtOutput);
    
                        return dtOutput;
                    }
                }
            }
 
            private void ExecuteQuery(string query, OleDbConnection conn)
            {
                using (OleDbCommand cmdInput = new OleDbCommand(query, conn))
                {
                    cmdInput.ExecuteNonQuery();
                }
            }

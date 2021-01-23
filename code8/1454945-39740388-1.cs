               //Read excell
                string input_Excell_fileName = @"Your Path";
                var connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + input_Excell_fileName + ";Extended Properties=\"Excel 12.0;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text\""; ;
                DataSet ds;
                using (var conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    var sheets = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * FROM [" + sheets.Rows[0]["TABLE_NAME"].ToString() + "] ";
    
                        var adapter = new OleDbDataAdapter(cmd);
                        ds = new DataSet();
                        adapter.Fill(ds);
                    }
                }

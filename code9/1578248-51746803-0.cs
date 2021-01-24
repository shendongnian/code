      private static DataTable ReadSqliteTable(string DBfile, string tableName,string wherestatement = "")
        {
            try
            {
                using (var conn = new SQLiteConnection("Data Source=" + DBfile))
                {
                    if (conn.State != ConnectionState.Open) conn.Open();
                    SQLiteDataAdapter sQLiteData = new SQLiteDataAdapter("SELECT * FROM " + tableName + wherestatement, conn);
                    DataTable table = new DataTable(tableName);
                    sQLiteData.Fill(table);
                    return table;
                }
            }
            catch { return null; };           
        }

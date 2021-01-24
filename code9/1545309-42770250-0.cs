        private static DataSet ExecuteDataset(string DBLocation, string query)
        {
            var conn = new SQLiteConnection("Data Source=" + DBLocation + ";Version=3;");
            DataSet ds;
            try
            {
                conn.Open();
                ds = new DataSet();
                var da = new SQLiteDataAdapter(query, conn);
                da.Fill(ds);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }

        private DataSet ExecuteDataset(string query)
        {
            var conn = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + Database + ";User Id=" + Username + ";Password=" + Password + ";");
            DataSet ds;
            try
            {
                conn.Open();
                ds = new DataSet();
                var da = new SqlDataAdapter(query, conn);
                da.Fill(ds);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Dispose();
                conn.Close();
            }
            return ds;
        }
           private DataSet ExecuteDataset(string query, SqlParameter[] parametros)
            {
                var conn = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + Database + ";User Id=" + Username + ";Password=" + Password + ";");
                DataSet ds;
                try
                {
                    conn.Open();
    
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = query;
    
                    foreach (SqlParameter p in parametros)
                    {
                        command.Parameters.Add(p);
                    }
    
                    ds = new DataSet();
                    var da = new SqlDataAdapter(command);
                    da.Fill(ds);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    conn.Dispose();
                    conn.Close();
                }
                return ds;
            }

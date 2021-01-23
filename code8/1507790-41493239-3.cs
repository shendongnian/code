        private void ExecuteNonQuery(string query)
        {
            var conn = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + Database + ";User Id=" + Username + ";Password=" + Password + ";");
            try
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = query;
                command.ExecuteNonQuery();
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
        }
        private void ExecuteNonQuery(string query, SqlParameter[] parametros)
        {
            var conn = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + Database + ";User Id=" + Username + ";Password=" + Password + ";");
            try
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = query;
                foreach (SqlParameter p in parametros)
                {
                    command.Parameters.Add(p);
                }
                command.ExecuteNonQuery();
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
        }

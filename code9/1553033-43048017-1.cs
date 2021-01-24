        /// <summary>
        /// Get all of the SQL data from "tableName" using "connectionString" 
        /// </summary>        
        public static DataTable GetSqlDataAsDataTable(string tableName, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM [{0}]", tableName), connection))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            try
                            {
                                sda.Fill(dt);
                            }
                            catch (Exception)
                            {
                                // handle it
                            }
                            return dt;
                        }
                    }
                }
            }
        }

    DataTable dt = new DataTable();
                using (SqlConnection sqlConn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    string sql = "<ProcedureName>";
                    using (SqlCommand sqlCmd = new SqlCommand(sql, sqlConn))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@ServiceId", string.Join(',', servicesIds.ToArray()));
                      
                        sqlCmd.Parameters.AddWithValue("@Page", page);
                        sqlCmd.Parameters.AddWithValue("@PageSize", pageSize);
                        sqlConn.Open();
                        using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd))
                        {
                            sqlAdapter.Fill(dt);
                        }
                    }
                }

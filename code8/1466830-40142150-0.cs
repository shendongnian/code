        try
                {
                    using (SqlConnection sqlConnection = new SqlConnection("put your connection string here"))
                    {
                        sqlConnection.Open();
                        using (SqlCommand sqlCommand = new SqlCommand("select EmpId,Fullname from Employee where FullName like @LeaderName", sqlConnection))
                        {
                            sqlCommand.CommandType = System.Data.CommandType.Text;
                            sqlCommand.Parameters.Add("@LeaderName", SqlDbType.VarChar).Value = leadername;
                            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                            while (sqlDataReader.Read())
                            {
                                var item = sqlDataReader[0];
                            }
                        }
                    }
                }
                catch (Exception ex) { throw new System.ArgumentException(ex.Message); }

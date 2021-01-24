    public static DataSet GetRecordWithExtendedTimeOut(string SPName, params SqlParameter[] SqlPrms)
        {
            DataSet ds = new DataSet();
            try
            {
                //here give reference of your connection and that is "openCon"
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(SPName, conn))
                    {
                        command.Parameters.AddRange(SqlPrms);
                        command.CommandTimeout = 0;
                        conn.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {
                            try
                            {
                                dataAdapter.SelectCommand = command;
                                dataAdapter.Fill(ds);
                            }
                            catch (Exception ex)
                            {                                
                                return null;
                            }
                            finally
                            {
                                conn.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Handle Errror
            }
            return ds;          
        }

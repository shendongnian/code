                    conn.Open();
                    SqlCommand dCmd = new SqlCommand("store_procedure_name",conn);
                    dCmd.CommandType = CommandType.StoredProcedure;
                    dCmd.Parameters.Add(new SqlParameter("@parameter2",parameter2));
                    dCmd.Parameters.Add(new SqlParameter("@parameter1", parameter1));
                    SqlDataAdapter da = new SqlDataAdapter(dCmd);
                    DataTable table = new DataTable();
                    ds.Clear();
                    da.Fill(ds);
                    conn.Close();
                    var das = ds.Tables[0].AsEnumerable();
                    #endregion
                }
                catch
                {
                }
            
           
       

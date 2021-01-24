    public DataSet Local_GetDataSet(string SQL)
        {
           
                SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
                SqlDataAdapter adapter;
                try
                {
    
                    adapter = new SqlDataAdapter(SQL, connection);
                    adapter.SelectCommand.CommandTimeout = CommandTimeOut;
                    DataSet mydata = new DataSet();
                    adapter.Fill(mydata);
                    adapter.Dispose();
                    connection.Close();
                    return mydata;
                }
                catch (Exception e)
                {
                    if (connection.State != ConnectionState.Closed) connection.Close();
                    throw new Exception("Data Base Error: " + e.Message);
                   
                }
            
           
    
        }

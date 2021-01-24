    public static DataSet ExecuteDataset(SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    		{
    			//create a command and prepare it for execution
    			SqlCommand cmd = new SqlCommand();
    			PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters);
    			
    			//create the DataAdapter & DataSet
    			SqlDataAdapter da = new SqlDataAdapter(cmd);
    			DataSet ds = new DataSet();
    
    			//fill the DataSet using default values for DataTable names, etc.
    			da.Fill(ds);
    			
    			//return the dataset
    			return ds;
    		}

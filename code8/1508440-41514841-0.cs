    public static class SqlDataAdapterExtension
    {
        public static void InitializeCommandsFor(this SqlDataAdapter adapter, string type)
        {
            SqlCommand selectCommand;
            SqlCommand insertCommand;
            SqlCommand updateCommand;
            SqlCommand deleteCommand;
            SqlDataAdapter dataAdapter;
    
            adapter.SelectCommand = new SqlCommand("Get" + type + "Data", cntn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                
            adapter.InsertCommand = new SqlCommand("Insert" + type, cntn);
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
            
            adapter.UpdateCommand = new SqlCommand("Update" + type, cntn);
            adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
                
            adapter.DeleteCommand = new SqlCommand("Delete" + type, cntn);
            adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
    
            cntn.Open();
            SqlCommandBuilder.DeriveParameters(adapter.SelectCommand);
            cntn.Close();
        }
    }

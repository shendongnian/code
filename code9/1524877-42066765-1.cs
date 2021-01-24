    //SqlConnection connection = ...;
	connection.InfoMessage +=  new SqlInfoMessageEventHandler(OnInfoMessage);
      
    // ... create a SqlCommand from this connection and run cmd.ExecuteNonQuery() ...
	void OnInfoMessage(object sender, SqlInfoMessageEventArgs args)
	{
		foreach (SqlError err in args.Errors)
		{
            //Console.WriteLine
			MessageBox.Show("The " + err.Source + " has received a severity " + err.Class + ", state " + err.State + "\n" +
			"on line " + err.LineNumber + ":\n" + err.Message);
		}
	} 

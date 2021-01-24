    private DataTable PopulateSomeDatatSet(DataSet aDataset, string UserName, string Password)
    {
    	var query = "SELECT * FROM tblUser WHERE Username = @Username and Password = @Password";
    	MySqlDataAdapter sda;
    	using (SqlConnection connStr = new SqlConnection(ConnString)) //replace with your ConnectionString Variable
    	{
    		using (MySqlCommand cmd = new MySqlCommand(query, connStr))
    		{
    			cmd.CommandType = CommandType.Text;
    			cmd.Parameters.Add("@Username", MySqlDbType.VarChar).Value = UserName;
                cmd.Parameters.Add("@Password", MySqlDbType.VarChar).Value = Password;
    			sda = new MySqlDataAdapter(cmd);
    			new MySqlDataAdapter(cmd).Fill(aDataset);
    		}
    	}
    	((IDisposable)sda).Dispose();
    	return aDataset.Tables[0];
    }

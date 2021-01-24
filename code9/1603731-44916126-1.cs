    Conn.Open();
    Command.CommandText = "Select SUM(c_qty) as sum, Count(*) as count from COLLVAULT_COINS WHERE c_type <> 'US Currency' AND c_type <> 'World Currency' AND c_type <> 'World Coins' AND c_listName = '" + activeCollection + "'";    //
    
    int total_matches = 0;
    using (MySqlDataReader dataReader = Command.ExecuteReader())
    {
        if (dataReader.Read()) 
        {
        	lblcollectedcount.Text = Convert.ToString(dataReader["sum"]);
        	total_matches = Convert.ToInt32(dataReader["count"]);
    	} 
    	else 
    	{
    		//nothing was read, handle that case
        }
    }
    Conn.Close();

       const string DB_CONN_STR = "Server=etc;Uid=etc;Pwd=etc;Database=etc;";
        MySqlConnection cn = new MySqlConnection(DB_CONN_STR);
        try {
            string sqlCmd = "SELECT PicAddress FROM [YourTable] where Id == PicAddress id";
            cn.Open(); // have to explicitly open connection (fetches from pool)
            MySqlCommand cmd = new MySqlCommand(sqlCmd, cn);
            cmd.CommandType = CommandType.Text;
            MySqlDataReader rdr = cmd.ExecuteReader();
			
			while(rdr.Read())
			{
				string url = rdr["Name of the Field Assuming PicAddress"].ToString(); 
				Image1.ImageUrl = url; 
			}
		}
		catch(Exception ex)
		{
			throw ex; 
		}

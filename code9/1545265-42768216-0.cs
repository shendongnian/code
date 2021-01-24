    public static void ValidateName(List<Employees> EmpList, string Grp)
    {
    	var connStr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
    
    	string selectQuery;
    	selectQuery = "Select EmpName from Employee where group = @Grp  AND @Name in (FirstName, LastName);";
    	using (MySqlConnection conn = new MySqlConnection(connStr)) {
    		conn.Open();
    		using (MySqlCommand cmd = new MySqlCommand(selectQuery, conn))
    		{			
    			var prmGrp = cmd.Parameters.Add("@Grp", MySqlDbType.VarChar);
    			var prmName = cmd.Parameters.Add("@Name", MySqlDbType.VarChar);
    			cmd.Prepare();
    			for (int i = 0; i < EmpList.Count; i++)
    			{
    				prmGrp.Value = Grp;
    				prmName.Value = EmpList[i].Name;
    			
    				using (var reader = cmd.ExecuteReader()) {
    					List<string> lineList = new List<string>();
    					while (reader.Read())
    					{
    						lineList.Add(reader.GetString(0));
    					}
    					if (lineList.Count <=0)
    					{
    						WriteValidationFailure(EmpList[i], "Name doesnot exists in the DB");
    					}
    				}
    			}			
    		}
    		conn.Close();
    	}       	
    }

	//create a new td connection
	TdConnection cn = new TdConnection();
	//Build the connection string
	TdConnectionStringBuilder connectionStringBuilder = new TdConnectionStringBuilder();
	connectionStringBuilder.DataSource = "serveraddress";
	connectionStringBuilder.Database = "defaultdatabase";
	connectionStringBuilder.UserId = "username";
	connectionStringBuilder.Password = "password";
    connectionStringBuilder.AuthenticationMechanism = "LDAP";
	connectionStringBuilder.CommandTimeout = 120; 
	//Open the connection
	cn.ConnectionString = connectionStringBuilder.ConnectionString;
	cn.Open();
	// Initialize TdCommand from the tdconnection
	TdCommand cmd = cn.CreateCommand();
	//CommandText is set to Stored Procedure name, in this case,
	//.NET Data Provider will generate the CALL statement.
	cmd.CommandText = "yourdatabasename.yourprocname";
	cmd.CommandType = CommandType.StoredProcedure;
	// Create Input Parameter required by this procedure
	TdParameter InParm1 = cmd.CreateParameter();
	InParm1.Direction = ParameterDirection.Input;
	InParm1.DbType = DbType.String;
	InParm1.Size = 20;
	InParm1.Value = "yourparamvalue";
	
	//and bind it
	cmd.Parameters.Add(InParm1);
	//------------OPTION 1 CATCHING AN OUTPUT PARAMETER---------------------
		//If you are catching an output parameter from a proc then create here:
		// Create Output Parameter.
		TdParameter OutParm = cmd.CreateParameter();
		OutParm.Direction = ParameterDirection.Output;
		OutParm.ParameterName = "myOutputParam";
		OutParm.DbType = DbType.String;
		OutParm.Size = 200;
		cmd.Parameters.Add(OutParm);
		
		// Run it up
		cmd.ExecuteReader()
		
		//if this is returning a single value you can grab it now:
		myOutput = OutParm.Value.ToString();
	
	
	//------------OPTION 2 CATCHING A RECORDSET-----------------------------
	
		//list based on class set in seperate model
		List<myClass> l_myclass = new List<myClass>();
		
		//run it up and catch into a TDDataRead
		using (TdDataReader r = cmd.ExecuteReader())
		{
			if (r.HasRows)
			{
				//Loop the result set and catch the values in the list
				while (r.Read())
				{
					//"myclass" class defined in a seperate model
                    //Obviously you could do whatever you want here, but
                    //creating a list on a class where the column1-column4 is defined makes short work of this. 
                    //Then you can dump the whole l_myclass as json back to the client if you want.
					myClass i = new myClass();
					i.column1 = (!r.IsDBNull(0)) ? r.GetString(0) : string.Empty;
					i.column2 = (!r.IsDBNull(1)) ? r.GetString(1) : string.Empty;
					i.column3 = (!r.IsDBNull(2)) ? r.GetString(2) : string.Empty;
					i.column4 = (!r.IsDBNull(3)) ? r.GetString(3) : string.Empty;
					l_myClass.Add(i);
				}
			}
		}
        //Dump the list out as json (for example)
        return Json(l_myClass, System.Web.Mvc.JsonRequestBehavior.AllowGet); 

    using (SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["TestControl.Properties.Settings.DB"].ConnectionString))
    {
    	boAPI4.Login login = new boAPI4.Login();
    	string cS = login.GetConnectionString();
    	DataAccess dA = new DataAccess(cS);
    	int userID = dA.getLpeID(login.GetBoUserNr());
    	PRAESENZZEIT q = new PRAESENZZEIT();
    
    	q.ZPZ_LPE_ID = userID;
    	if (db.State == ConnectionState.Closed)
    		db.Open();
    	string query = "SELECT per.LPE_Nr, zei.ZPZ_LPE_ID, zei.ZPZ_Datum, SUM (zei.ZPZ_Std100) AS ZPZ_Std100" +
    				   " FROM DB.dbo.Z_PRAESENZZEIT zei INNER JOIN DB.dbo.A_PERSONAL per ON zei.ZPZ_LPE_ID = per.LPE_ID" +
    					$" WHERE zei.ZPZ_Datum BETWEEN '{dtFromDate.Value}' AND '{dtToDate.Value}' AND zei.ZPZ_LPE_ID='{userID.ToString()}' GROUP BY per.LPE_Nr, zei.ZPZ_LPE_ID, zei.ZPZ_Datum ORDER BY zei.ZPZ_Datum, per.LPE_Nr;";
    
    	pRAESENZZEITBindingSource.DataSource = db.Query<PRAESENZZEIT>(query, commandType: CommandType.Text);
    
    	List<PRAESENZZEIT> listid = new List<PRAESENZZEIT>();
    	//PRAESENZZEIT pra = new PRAESENZZEIT(); //Needs to be inside the while loop.
    	SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TestControl.Properties.Settings.DB"].ConnectionString);
    	string sql = "SELECT ZPZ_Von,ZPZ_bis FROM  DB.dbo.Z_PRAESENZZEIT WHERE ZPZ_LPE_ID='196'";
    	con.Open();
    	SqlCommand cmd = new SqlCommand(sql, con);
    	SqlDataReader dr = cmd.ExecuteReader();
    
    	while (dr.Read())
    	{
    		PRAESENZZEIT pra = new PRAESENZZEIT();
    		pra.ZPZ_Von = Convert.ToDateTime(dr["ZPZ_Von"]);
    		pra.ZPZ_Bis = Convert.ToDateTime(dr["ZPZ_bis"]);
    		listid.Add(pra);
    		
    		DateTime kommen = DateTime.Now;
    
    		kommen = pra.ZPZ_Von;
    		if (pra.ZPZ_Von.TimeOfDay < new TimeSpan(8, 5, 0))
    			pra.ZPZ_Von = new DateTime(pra.ZPZ_Von.Year, pra.ZPZ_Von.Month, pra.ZPZ_Von.Day, 8, 0, 0);
    
    		DateTime gehen = DateTime.Now;
    		gehen = pra.ZPZ_Bis;
    		TimeSpan arbeitszeit = pra.ZPZ_Bis - pra.ZPZ_Von;
    	}
    	dataGridView1.DataSource = listid;
    	con.Close();
    }

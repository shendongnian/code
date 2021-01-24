    using(SqlCommand cmd = new SqlCommand(query, db))
    {
    	using(SqlDataAdapter da = new SqlDataAdapter(cmd))
    	{
    		using(SqlDataReader dr = cmd.ExecuteReader())
    		{
    			
    			var items = new BindingList<PRAESENZZEIT>();
    			
    			while (dr.Read())
    			{
    				PRAESENZZEIT pra = new PRAESENZZEIT();
    				
    				pra.ZPZ_Von = Convert.ToDateTime(dr["ZPZ_Von"]);
    				if (pra.ZPZ_Von.TimeOfDay < new TimeSpan(8, 5, 0))
    					pra.ZPZ_Von = new DateTime(pra.ZPZ_Von.Year, pra.ZPZ_Von.Month, pra.ZPZ_Von.Day, 8, 0, 0);
    				
    				// DateTime gehen = DateTime.Now;
    				pra.ZPZ_Bis = Convert.ToDateTime(dr["ZPZ_Bis"]);
    				pra.arbeitszeit = pra.ZPZ_Bis - pra.ZPZ_Von;
    			}
    			
    			pRAESENZZEITBindingSource.DataSource = items;
    		}
    	}
    }

    public void checkCodeinDb()
	{
		
			using (IDbConnection dbConnection = new SqliteConnection (connectionString))
			{
				dbConnection.Open ();
				using (IDbCommand dbCmd = dbConnection.CreateCommand ())
				{
					string sqlQuery = "select slno from CampWheelDenomination where quota_allowded = 0";
					dbCmd.CommandText = sqlQuery;
					using (IDataReader reader = dbCmd.ExecuteReader ())
					{
						while (reader.Read ()) 
						{
							
						
					
						
						string ad = reader ["slno"].ToString();
						
						SlNoList.Add (ad);
						}
				
				
				
					foreach (string st in SlNoList)
					{
						print (st);
					}     
				
						dbConnection.Close ();
						reader.Close ();
					}
				}
			}
		}

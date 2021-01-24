    public IList getRents()
	{
		using (var con = new SqlConnection(sCon))
		{
            var query = "SELECT r.RentID,c.CustomerName,v.VehicleName,r.[Hours], r.[Hours] * v.Rent AS Total FROM Rent as r INNER JOIN Customer AS c ON r.CustomerID = c.CustomerID INNER JOIN Vehicle AS v ON r.VehicleID = v.VehicleID";
			using (var com = new SqlCommand(query, con))
			{
				con.Open();
				using (var reader = com.ExecuteReader())
				{
                    IList result = new List<Rent>();
					while (reader.Read())
					{
						Rent r = new Rent();
						r.rentID = (int)reader[0];
						r.customerID = (int)reader[1];
						r.vehicleID = (int)reader[2];
						r.hours = (int)reader[3];
						//r.total = (int)reader[4];
						result.Add(r);
					}
					return result;
				}
			}
		}
	}

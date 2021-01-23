    public IEnumerable<LocationInfo> GetData()
    {
            List<LocationInfo> locations = new List<LocationInfo>();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString))
            using (SqlCommand command = new SqlCommand(@"SELECT .... ", connection))
            {
                connection.Open();
                
                using (var reader = command.ExecuteReader())
                {
                    LocationInfo x = new LocationInfo();
                    while(reader.Read())
                    {
                       
                        {
                            x.Names = reader.GetString(2),
                            x.Values=Math.Round(reader.GetDouble(7),2).ToString("#,##0.00"),
                            x.ValuesDouble = reader.GetDouble(7),
                            Values2 = Math.Round(reader.GetDecimal(9), 2).ToString("#,##0.00"),
                            x.ValuesDouble2 = reader.GetDecimal(9),
                            x.truckDelivery=reader.GetDecimal(3),
                            x.truckIdle = reader.GetDecimal(4),
                            x.truckRepair = reader.GetDecimal(5),
                            x.truckReady = reader.GetDecimal(6),
                            x.presentEmp=reader.GetInt32(11),
                            x.absentEmp = reader.GetInt32(12),
                            x.ondutyEmp = reader.GetInt32(13),
                        };
                        
                    }
                    if(reader.NextResult())
                    {
                     while (reader.Read())
                     {
                      x.SumVol=reader.GetString(0);
                     }
                    }
                    locations.Add(x);
                }
            }
            return locations;
    }

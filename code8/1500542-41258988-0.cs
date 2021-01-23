    public IEnumerable<LocationInfo> GetData()
    {
        List<LocationInfo> locations = new List<LocationInfo>();
        using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString))
        using (SqlCommand command = new SqlCommand(@"SELECT .... ", connection))
        {
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    LocationInfo x = new LocationInfo()
                    {
                        Names = x.GetString(2),
                        Values = Math.Round(x.GetDouble(7), 2).ToString("#,##0.00"),
                        ValuesDouble = x.GetDouble(7),
                        Values2 = Math.Round(x.GetDecimal(9), 2).ToString("#,##0.00"),
                        ValuesDouble2 = x.GetDecimal(9),
                        truckDelivery=x.GetDecimal(3),
                        truckIdle = x.GetDecimal(4),
                        truckRepair = x.GetDecimal(5),
                        truckReady = x.GetDecimal(6),
                        presentEmp=x.GetInt32(11),
                        absentEmp = x.GetInt32(12),
                        ondutyEmp = x.GetInt32(13),
                    };
                    locations.Add(x);
                }
            }
        }
        return locations;
    }

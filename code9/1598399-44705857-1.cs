    public IList GetRents()
    {
        using(var conn = new SqlConnection(sCon))
        {
            var query = "SELECT r.RentID,c.CustomerName,v.VehicleName,r.[Hours], r.[Hours] * v.Rent AS Total FROM Rent as r INNER JOIN Customer AS c ON r.CustomerID = c.CustomerID INNER JOIN Vehicle AS v ON r.VehicleID = v.VehicleID";
            return conn.Query<Rent>(sql).ToList();
        }
    }

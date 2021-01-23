    using (var connection = new SqlConnection("Connection string of the first db"))
    {
        return connection.Query<Events>("GetEvents", commandType: CommandType.StoredProcedure).ToList();
    }
    using (var connection = new SqlConnection("Connection string of the second db"))
    {
        return connection.Query<Events>("GetEvents", commandType: CommandType.StoredProcedure).ToList();
    }

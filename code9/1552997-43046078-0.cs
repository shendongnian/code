    using (IDbConnection dbConnection = Connection)
    {
       dbConnection.Open() //<--open the connection
       var reader = dbConnection.ExecuteReader(sql);
        ...

    using (var pgConnection = new PgSqlConnection(myConnection))
    {
        pgConnection.Open();
        var mySelectQuery = "YOUR QUERY HERE";
        var results = pgConnection.Query<SomeClass>(mySelectQuery);
    }

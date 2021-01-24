    using(var connection = new OracleConnection())
    {
        MyAgnosticDatabaseMethod(connection);
    }
    using(var connection = new SqlConnection())
    {
        MyAgnosticDatabaseMethod(connection);
    }

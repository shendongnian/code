    void MyAgnosticDatabaseMethod(IDbConnection connection)
    {
        using(var command = connection.CreateCommand())
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = "@answer";
            parameter.Value = 42;
            command.Parameters.Add(parameter);
            /// and so forth
        }
    }

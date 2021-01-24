    public IEnumerable<AllianceReputationRank> GetAllianceReputationRanks(string whereClause, IEnumerable<SqlParameter> parameters)
    {
        // Get a connection string from somewhere
        var connectionString = string.Empty;
        using (var connection = new SqlConnection(connectionString))
        using (var command = new SqlCommand("SELECT * FROM alliance_reputation_rankings " + (whereClause ?? string.Empty), connection))
        {
            connection.Open();
            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    // Build a list or use `yield return`, if building a list instance here
                    while (reader.Read())
                    {
                        // Build a model of `AllianceReputationRank` here
                        // Use reflection or just add each property manually
                        // Make sure you read `reputation` as a string, then `BigInteger.Parse` it to your model
                        // Either add the model to the list or `yield return model`
                    }
                    // If you built a list then `return` it
                }
            }
        }
    }

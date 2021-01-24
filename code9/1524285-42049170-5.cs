    public IEnumerable<AllianceReputationRank> GetAllianceReputationRanks(string whereClause, IEnumerable<MySqlParameter> parameters)
    {
        // Get a connection string from somewhere
        var connectionString = string.Empty;
        using (var connection = new MySqlConnection(connectionString))
        using (var command = new MySqlCommand("SELECT * FROM alliance_reputation_rankings " + (whereClause ?? string.Empty), connection))
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
                    var result = new List<AllianceReputationRank>();
                    while (reader.Read())
                    {
                        // Build a model of `AllianceReputationRank` here
                        var model = new AllianceReputationRank();
                        // Use reflection or just add each property manually
                        model.Date = reader.GetDate("date");
                        // ...
                        // Make sure you read `reputation` as a string, then `BigInteger.Parse` it to your model
                        model.Reputation = BigInteger.Parse(reader.GetString("reputation"));
                        // Either add the model to the list or `yield return model`
                        result.Add(model);
                    }
                    // If you built a list then `return` it
                    return result;
                }
            }
        }
    }

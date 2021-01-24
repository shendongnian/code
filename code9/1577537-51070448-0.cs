    private DbQuery<ExampleStoredProc_Result> ExampleStoredProc_Results { get; set; }
    public IEnumerable<ExampleStoredProc_Result> RunExampleStoredProc(int firstId, out bool outputBit)
    {
        var outputBitParameter = new SqlParameter
        {
            ParameterName = "outputBit",
            SqlDbType = SqlDbType.Bit,
            Direction = ParameterDirection.Output
        };
        SqlParameter[] parameters =
        {
            new SqlParameter("firstId", firstId),
            outputBitParameter
        };
        // Need to do a ToList to get the query to execute immediately 
        // so that we can get both the results and the output parameter.
        string sqlQuery = "Exec [ExampleStoredProc] @firstId, @outputBit OUTPUT";
        var results = ExampleStoredProc_Results.FromSql(sqlQuery, parameters).ToList();
        outputBit = outputBitParameter.Value as bool? ?? default(bool);
        return results;
    }

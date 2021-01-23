    //Sample data
    Dictionary<int, object> lParameters = new Dictionary<int, object>();
    lParameters.Add(1, 1);
    lParameters.Add(2, "Peter");
    lParameters.Add(3, 22);
    lParameters.Add(4, 2);
    lParameters.Add(5, "John");
    lParameters.Add(6, 24);
    lParameters.Add(7, 3);
    lParameters.Add(8, "Glenn");
    lParameters.Add(9, 33);
    using (SqlConnection conn = new SqlConnection(@"Your connection string"))
    {
        conn.Open();  
        using (SqlCommand lCommand = new SqlCommand("query", conn))
        {
            lCommand.Parameters.AddRange(
                lParameters.Select(x => new SqlParameter($"@{x.Key}", x.Value)).ToArray());
            for (int i = 1; i <= lParameters.Count; i+=3)
            {
                lCommand.CommandText = $"INSERT INTO[dbo].[TestDB]([ID], [Name], [Age]) 
                                         VALUES(@{i}, @{i + 1}, @{i + 2});";      
                lCommand.ExecuteNonQuery();
            }
        }
    }

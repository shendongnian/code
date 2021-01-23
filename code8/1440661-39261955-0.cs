    var ExampleInput = { "foo", "bar", "daily", "special" };
    List<int> tempReturnData = new List<int>();
    
    using (var sqlConnection1 = new SqlConnection("FooBar Connection String"))
    {
        using (var cmd = new SqlCommand()) 
        {
            cmd.Connection = sqlConnection1;
    
            // generate something like 'foo','bar','daily', 'special' into the string
            string parameterValue = string.Concat("'", string.Join("','", ExampleInput), "'");
    
            // execute the single query
            cmd.CommandText = string.Format("SELECT [int] FROM [table] WHERE [string] IN ({0});",  parameterValue);
            
            sqlConnection1.Open();
    
            using (var reader = cmd.ExecuteReader()) 
            {
                // add all ements on the listof integers
                while (reader.Read())
                    tempReturnData.Add(reader.GetInt32(0));        
            }
    
            reader.Close();
            sqlConnection1.Close();
        }
    }
    // get the final list of ints as array
    int[] ReturnData = tempReturnData.ToArray();

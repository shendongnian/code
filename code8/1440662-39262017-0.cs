    string[] ExampleInput = { "foo", "bar", "daily", "special" };
    int[] ReturnData = new int[ExampleInput.GetUpperBound(0)];
    using (SqlConnection sqlConnection1 = new SqlConnection("FooBar Connection String")) 
    {
        sqlConnection1.Open();
        for (int i = 0; i <= ExampleInput.GetUpperBound(0); i++)
        {         
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;
                cmd.CommandText = "SELECT [int] FROM [table] WHERE [string] = '" + ExampleInput[i] + "'; ";
                
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        ReturnData[i] = reader.GetInt32(0);
                }
            }            
        }
    }

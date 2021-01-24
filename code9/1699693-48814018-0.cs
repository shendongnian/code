    JsonTextReader reader = new JsonTextReader(new StringReader(json));
    while (reader.Read())
    {
        if (reader.Value != null)
        {
            Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
        }
        else
        {
            Console.WriteLine("Token: {0}", reader.TokenType);
        }
    }

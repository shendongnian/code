    JsonTextReader rs = new JsonTextReader(new StringReader("{'1':'2'}"));
    Console.WriteLine("TokenType     Value");
    Console.WriteLine("------------  ------");
    while (rs.Read())
    {
        Console.WriteLine(string.Format("{0,-12}  {1}", 
            rs.TokenType.ToString(),
            rs.Value != null ? rs.Value.ToString() : "(null)"));
    }

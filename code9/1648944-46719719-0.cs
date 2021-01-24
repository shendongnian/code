    string json = "{'1':'2'}";
    JsonTextReader rs = new JsonTextReader(new StringReader(json));
    Console.WriteLine("TokenType     Value");
    Console.WriteLine("------------  ------");
    while (rs.Read())
    {
        Console.WriteLine(string.Format("{0,-12}  {1}", 
            rs.TokenType.ToString(),
            rs.Value != null ? rs.Value.ToString() : "(null)"));
    }

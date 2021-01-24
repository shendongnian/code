    public static string GetJsonProperties(string json)
    {
        string outputString = "";
        JsonTextReader reader = new JsonTextReader(new StringReader(json));
        //don't do date conversion, but get them as their verbatim string.
        reader.DateParseHandling = DateParseHandling.None;
        while (reader.Read())
        {
            if (reader.Value != null)
            {
                //We are not interested in the name of properties..
                if (reader.TokenType != JsonToken.PropertyName)
                    outputString += reader.Value;
            }
        }
        return outputString;
    }
    
    public static void Main(string[] args)
    {
        string someJson = 
            "{ "+
            "  \"invoicenr\": \"315.80042\", " +
            "  \"invoiceid\": 3474838, " +
            "  \"invoicedate\": \"2017-09-20T00:00:00+02:00\"," +
            "  \"invoicetype\": \"C\", " +
            "  \"invoicemethod\": \"I\", " +
            "  \"invoicemailby\": \"M\"," +
            "  \"amountex\": -0.01," +
            "  \"amountin\": 0," +
            " \"someArray\" : [1,2,3]," +
            " \"subObj\": { \"a\":42, \"b\":1337} " +
            "}";
    
        Console.WriteLine(GetJsonProperties(someJson));
        Console.ReadLine();
    }

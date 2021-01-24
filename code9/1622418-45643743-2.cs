    public static void PrintJson(string json)
    {
        JsonReader reader = new JsonReader(json);
        Console.WriteLine ("{0,14} {1,10} {2,16}", "Token", "Value", "Type");
        Console.WriteLine (new String ('-', 42));
        // The Read() method returns false when there's nothing else to read
        while (reader.Read()) {
            string type = reader.Value != null ?
                reader.Value.GetType().ToString() : "";
            Console.WriteLine("{0,14} {1,10} {2,16}",
                              reader.Token, reader.Value, type);
        }
    }

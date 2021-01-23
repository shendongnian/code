    string json = "{\"Result\":     {         \"aString\":\"Read me please!\",     \"anotherString\":\"Dont read me!\"     }            }";
    using (var reader = new JsonTextReader(new StringReader(json)))
    {
        while (reader.Read())
        {
            if (reader.TokenType == JsonToken.PropertyName && (string)reader.Value == "aString")
            {
                reader.Read();
                Console.Write(reader.Value);
                break;
            }
        }
    }
    Console.ReadKey();

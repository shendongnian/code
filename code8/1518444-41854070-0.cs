    while (reader.Read())
    {
         Console.WriteLine(reader.GetString(0));
    }
    if (reader.NextResult())
    {
        while (reader.Read())
        {
            Console.WriteLine(reader.GetString(0));
        }
    }

    while (reader.Read())
    {
        var s = reader.GetString(0);
        if (!numb.Contains(s))
        {
            numb.Add(s);
        }
    }

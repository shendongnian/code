    MySqlCommand[] copy;
    lock(sqlHistory)
    {
        copy = sqlHistory.ToArray();
        sqlHistory.Clear();
    }
    foreach(var command in copy)
    {
        // ...
    }

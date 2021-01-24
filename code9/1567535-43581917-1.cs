    MySqlCommand[] copy;
    lock(_sqlHistory)
    {
        copy = _sqlHistory.ToArray();
        _sqlHistory.Clear();
    }
    foreach(var command in copy)
    {
        // ...
    }

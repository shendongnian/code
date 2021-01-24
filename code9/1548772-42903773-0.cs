    using (var conn = new SQLiteConnection(...))
    using (var selectCall = conn.Prepare("..."))
    {
        var t = selectCall.Step();
        ...
    }

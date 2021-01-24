    private void DoStuff(TableType1 item)
    {
        var db = new SQLiteConnection(_dbPath);
        var items = db.Table<TableType1>();
        // do stuff here...
        db.Close();
    }
    private void DoStuff(TableType2 item)
    {
        var db = new SQLiteConnection(_dbPath);
        var items = db.Table<TableType2>();
        // do stuff here...
        db.Close();
    }

    private void DoStuff(TableType itemType)
    {
        var db = new SQLiteConnection(_dbPath);
        var items = db.Table<TableType>();
        // do stuff here...
        db.Close();
    }

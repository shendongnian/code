    List<Object> models = new List<Object>();
    // ...
    // LocalConnection conn = ...;
    SQLiteConnection db = conn.GetSQLiteConnection();
    db.InsertAll(models,true); // the true means "run in transaction"

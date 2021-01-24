    using (System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection("data source=myDB.db3"))
    using (System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(conn))
    {
         conn.Open();
         using(SQLiteTransaction tr = conn.BeginTransaction())
         {
             cmd.Transaction = tr;
             .....
             for(....)
             {
                 .....
             }
             tr.Commit();
         }
    }

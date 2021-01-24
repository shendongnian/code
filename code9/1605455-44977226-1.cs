    interface ISqlite
    {
        T select<T>(SQLiteDatabase db);
    }
    
    class myClass : ISqlite
    {
        public DataTable select<DataTable>(SQLiteDatabase db)
        {
            // do stuff here
        }
    }
    
    class myClass2 : ISqlite
    {
        public Array select<Array>(SQLiteDatabase db)
        {
            // do stuff here
        }
    
    }

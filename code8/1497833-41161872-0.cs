    class DB1
    {
        public static readonly string Table1 = "schema.NameOfTable1"
        public static readonly string Table2 = "schema.NameOfTable2"
        static DB1() { SQL.sInitialCatalog = SQL.DB_AppData; }
    }
string table_name = DB1.Table1; //Retrieves table name and updates InitialCatalog

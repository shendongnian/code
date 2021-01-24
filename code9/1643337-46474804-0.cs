    SQLiteConnectionStringBuilder lcb = new SQLiteConnectionStringBuilder();
    lcb.JournalMode = SQLiteJournalModeEnum.Off;
    lcb.DataSource = sqlFile;
    lcb.Version = 3;
    
    string myLtConnStr = lcb.ConnectionString;

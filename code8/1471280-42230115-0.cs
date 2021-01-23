    private SQLiteDatabaseConnection _dbcon;
    public SQLiteDatabaseConnection DbConnection
    {
        get
        {
            if (_dbcon == null)
            {
                Func<ISQLiteValue, ISQLiteValue, ISQLiteValue> regexFunc = 
                    (ISQLiteValue val, ISQLiteValue regexStr) =>
                    {
                        if (Regex.IsMatch(Convert.ToString(val), Convert.ToString(regexStr)))
                            return true.ToSQLiteValue();
                        return false.ToSQLiteValue();
                    };
                if (_dbname == null)
                    _dbcon = SQLiteDatabaseConnectionBuilder
                            .InMemory
                            .WithScalarFunc("REGEXP", regexFunc)
                            .Build();
                else
                    _dbcon = SQLiteDatabaseConnectionBuilder
                            .Create(_dbname)
                            .WithScalarFunc("REGEXP", regexFunc)
                            .Build();
            }
            return _dbcon;
        }
    }

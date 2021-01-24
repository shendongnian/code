    //Allows for a default value if none is passed
    public PrimaryContext() : base(Settings.Default.db) { }
    public PrimaryContext(string connection) : base(connection)
    {
    }

    static TechsportiseData database;
    public static TechsportiseData Database
    {
        get
        {
            if (database == null)
            {
                database = new TechsportiseData(DependencyService.Get<IFileHelper>().GetLocalFilePath("TechsportiseData.db3"));
            }
            return database;
        }
    }

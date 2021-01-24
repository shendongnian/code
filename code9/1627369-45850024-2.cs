    protected override OnAppearing()
    {
        BindingContext = new JobsModel {
            AllJobs = GetJobs()
        };
    }
    
    private List<Jobs> GetJobs()
    {
        var db = _connection.Table<Jobs>();
        return db.ToList();
    }

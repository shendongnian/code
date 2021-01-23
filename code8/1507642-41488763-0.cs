    public IEnumerable<DateTime> DateTimes()
    {
        using(DataContext dc = new DataContext(_connectionString))
        {
            dc.ExecuteQuery<DateTime>("select datetime from calendar");
        }
    }

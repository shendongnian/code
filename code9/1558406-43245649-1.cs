    public List<Cleaner> GetProfiles()
    {
        using (var context = new CleanerDataContext(_connectionString))
            {
                var loadOptions = new DataLoadOptions();
                
                loadOptions.LoadWith<Cleaner>(c => c.ProfileConfirmed);
                context.LoadOptions = loadOptions;
                
                var confirmedProfilers =
                                      from cust in db.SomeTable
                                      where c.ProfileConfirmed == true
                                      select cust;
               return confirmedProfilers.ToList();
            }
        }

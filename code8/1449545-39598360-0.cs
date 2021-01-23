    public IList<string> GetUserNames(DateTime specificDate)
    {
       var userNames = Entries.Where(x => x.Date == specificDate)
                           .Select(x => x.UserName)
                           .Distinct()
                           .ToList();
       return userNames;
    }

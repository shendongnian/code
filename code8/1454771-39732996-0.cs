    List<int> ids = o.Select(c => c.Id).ToList();
    
    using(DataClassesDataContext Context = new DataClassesDataContext())
    {
        var Customers = Context.Customers.Where(x => ids.Contains(x.Id));
    }

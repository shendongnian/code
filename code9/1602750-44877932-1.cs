    public static List<Table> TestFunction(Filters pParameter)
    {
        ExampleDataContext dc = new ExampleDataContext(Properties.Settings.Default.ExampleConnectionString);
        
        //all
        IQueryable<Table> SelectResult = dc.Table;
    
        //add conditions
        if (pParameter.A.count != 0 )
            SelectResult = SelectResult.Where(x => pParameter.A.Contains(x.B));
        if (pParameter.B.count != 0)
            SelectResult = SelectResult.Where(x => pParameter.A.Contains(x.B));
        //export, with one\two\zero conditions
        return SelectResult.ToList();
    }

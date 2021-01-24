    public int getNumberAutoNameDistinct()
    {
        testViewClassDataContext tv = new testViewClassDataContext();
        var autoNames = tv.test_views.Select(i => i.AutoName).Distinct().ToList();
       
        // do something with autoNames
           
        return autoNames.Count();
        }

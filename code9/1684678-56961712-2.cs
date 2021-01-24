    public static void Filter(Category category)
    {
        if(GlobalDefinitions.Category.HasFlag(category) == false)
           Assert.Inconclusive(); // do not perform test
        
        // else perform test                         
    }

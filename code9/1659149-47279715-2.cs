    using(MyDbContext ctx = new MyDbContext())
    {
        TimeSpan myTime = new TimeSpan(12, 00, 00);
        string myTimeString = myTime.ToString("hh':'mm':'ss");
        List<ExecutionObjects> tmp = ctx.ExecutionObjects.Where(a => a.ExecutionTime.EndsWith(myTimeString)).ToList();
        // Access field in source with seperated DateTime-property.
        tmp.ForEach(e => Console.WriteLine(e.ExecutionTimeDateTime.ToShortDateString()));
    }

    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    using(var db = new MyContext())
    {
        var q1 = from c in db.Customers where c.Id == 1 select c;
        var c1 = q1.First();
    }
    stopWatch.Stop();
    TimeSpan warmts = stopWatch.Elapsed;

    protected void Application_Start()
    {
        //measure the running time
        var stopWatch = new Stopwatch();
        stopWatch.Start();
    
        IEnumerable<object> result = from t in AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
            where t.GetInterfaces().Contains(typeof(IClassId)) &&
                    t.GetConstructor(Type.EmptyTypes) != null
            select Activator.CreateInstance(t) as IClassId;
    
        List<IGrouping<Guid, object>> lst = result.GroupBy(x => ((IClassId)x).ClassId)
            .Where(y => y.Count() > 1)
            .ToList();
        stopWatch.Stop();
    
        var elapsed = stopWatch.ElapsedMilliseconds;
    }

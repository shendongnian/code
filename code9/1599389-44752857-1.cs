    public void Execute(IJobExecutionContext context)
    {
        //Equivalent to a database query
        var pers = persions.Where(s => s.Status).ToList();
        //Exclude the object that was executed the previous time
        pers = pers.Where(s => !BaseProcessOperator<ScanJob>.GetProcesses().Contains(s.Name)).ToList();
        Action<List<Person>> doWork = (s) =>
        {
            BaseProcessOperator<ScanJob>.AddRange(s.Select(n => n.Name).ToList());//Add to intermediate variable
            DoWork(s);//Do something that can not be expected time (http request)
        };
        doWork.BeginInvoke(pers, (str) =>
        {
            //After DoWork() ends, organize the intermediate variables
            BaseProcessOperator<ScanJob>.Remove(pers, (s) => { return s.Name; });
        }, null);
        Console.ReadKey();
    }

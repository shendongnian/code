    protected override List<object> GetList(DateTime start, DateTime end)
    {
    	List<object> list = new List<object>();
    	object lockList = new object();
    
    	DateTime current = start;
    
    	List<Task> threads = new List<Task>();
    
    	do
    	{
    		current = new DateTime(Math.Min(current.AddMonths(1).Ticks, end.Ticks));
    
    		Task thread = Task.Run(GetMethodFunc(start, current)).ContinueWith((result) => 
    		{
    			lock (lockList)
    			{
    				list = list.Concat(result.Result).ToList();
    			}
    		});
    
    		threads.Add(thread);
    
    		start = current;
    	}
    	while (current < end);
    
    	Task.WhenAll(threads).Wait();
    
        return list;
    }
    
    private Func<List<object>> GetMethodFunc(DateTime start, DateTime end)
    {
    	return () => {
    		List<object> partialList = ExternalWebService.GetListByPeriod(from: start, to: end);
    		return partialList;
    	};
    }

    private async Task<PerformanceCounter[]> GetCounters(PerformanceCounterCategory category)
    {   
      List<Task<PerformanceCounter>> lstTask = new     
                         List<Task<PerformanceCounter>>();
      //your code 
     foreach(var instance in instances)
     {
       lstTask.Add( Task.Factory.StartNew(()=> return    
      category.GetCounters(instance)));
     }
       PerformanceCounter[] counter = await Task.WhenAll(lstTask.ToArray());
       return counter ;
    }

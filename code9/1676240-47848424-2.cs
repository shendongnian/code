    private async Task<List<PerformanceCounter>> GetCounters(PerformanceCounterCategory category)
    {   
      List<Task<PerformanceCounter>> lstTask = new     
                         List<Task<PerformanceCounter>>();
      List<PerformanceCounter> counters = new List<PerformanceCounter>();
      //your code 
     foreach(var instance in instances)
     {
       lstTask.Add( Task.Factory.StartNew(()=> return    
      category.GetCounters(instance)));
     }
 
      try {
         await Task.WhenAll(lstTask.ToArray());
      }
      catch {}  
      foreach(var task in lstTask )
      {
        if(task.Status != TaskStatus.Faulted)
           counters.Add(task.Result);
        else 
            //log error task.Exception
      }
  
       return counters ;
    }

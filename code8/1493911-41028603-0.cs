    public void ExecuteWithRetry(Action doWork, int maxTries=1) {
       for(var tryCount=1; tryCount<=maxTries; tryCount++){
          try{
             doWork();
          } catch(Exception ex){
             if(tryCount==MaxTriex){
               Console.WriteLine("Oops, no luck with DoWork()");
          }
       }
    }
  

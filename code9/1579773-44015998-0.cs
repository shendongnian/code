    public async Task<string> AddNewDataAsync(T arg1, ServiceContract c){
       if(arg1==val1){
         // Poll to see if the database is ready
         // or use some other method that returns a 
         // a task when it is ready
         while(!(await DataBaseReady())
             await Task.Delay(TimeSpan.FromSeconds(1));
       }
       return c.AddNewData();
    }
    public async Task<bool> IsDataBaseReady(){
        ....        
    }

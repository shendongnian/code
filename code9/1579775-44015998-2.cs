    const int val1 = 10;
    
    public class HelloService<int> : IServiceContract<T>
    {
        public async Task<string> AddNewData(int arg1)
        {
          if(arg1==val1){
             // Poll to see if the database is ready
             // or use some other method that returns a 
             // a task when it is ready
             while(!(await DataBaseReady())
                 await Task.Delay(TimeSpan.FromSeconds(1));
           }
           return "Got it"
        }
    }
    

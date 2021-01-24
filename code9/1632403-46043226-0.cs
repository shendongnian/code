    BackgroundJob.Schedule(() => {
      
        SomeProcessToComplete();
    
    },TimeSpan.FromMinutes(2));
    
    static void SomeProcessToComplete(){
       
         //after code runs add another job to the queue
        BackgroundJob.Schedule(
        () => Console.WriteLine("Delayed!"),
        TimeSpan.FromMinutes(2));
    }

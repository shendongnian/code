     static async void Work1()
     {
         Console.WriteLine("10 started");
        await Task.Delay(10000);
         Console.WriteLine("10 completed");
     }
    
     static async void Work2()
     {
         Console.WriteLine("3 started");
         await Task.Delay(3000);
         Console.WriteLine("3 completed");
     }
    
     static async void Work3()
     {
         Console.WriteLine("5 started");
         await Task.Delay(5000);
         Console.WriteLine("5 completed");
     }

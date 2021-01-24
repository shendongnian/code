    class Program
    {
       private static readonly AsyncLock _lock = new AsyncLock();
    
       private static async Task Test(int i, Task toComplete)
       {
          using (await _lock.EnterAsync())
          {
             await toComplete;
             Console.WriteLine(i);
          }
       }
    
       public static void Main(string[] args)
       {
          var tcs1 = new TaskCompletionSource<object>();
          var tcs2 = new TaskCompletionSource<object>();
    
          Task.Run(async () =>
          {
             var t1 = Test(1, tcs1.Task); // start first task
             var t2 = Test(2, tcs2.Task); // start second task
    
             tcs2.SetResult(null); // finish second first
             tcs1.SetResult(null); // fiish last task
    
             await Task.WhenAll(t1, t2); // will print: 1 and then 2
          }).Wait();
       }
    }

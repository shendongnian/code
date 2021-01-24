    class Program
    {
       //capture request running that , which need to be cancel in case
       // it take more time 
        static Thread threadToCancel = null;
        static async Task<string> DoWork(CancellationToken token)
        {
            var tcs = new TaskCompletionSource<string>();
            //enable this for your use
        //await Task.Factory.StartNew(() =>
        //{
        //    //Capture the thread
        //    threadToCancel = Thread.CurrentThread;
        //    HTTP_actions.put_import(...); 
        //});
        //tcs.SetResult("Completed");
        //return tcs.Task.Result;
        //comment this whole this is just used for testing 
            await Task.Factory.StartNew(() =>
            {
                //Capture the thread
                threadToCancel = Thread.CurrentThread;
    
                //Simulate work (usually from 3rd party code)
                for (int i = 0; i < 100000; i++)
                {
                    Console.WriteLine($"value {i}");
                }
    
                Console.WriteLine("Task finished!");
            });
    
            tcs.SetResult("Completed");
            return tcs.Task.Result;
        }
    
    
        public static void Main()
        {
            var source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            DoWork(token);
            Task.Factory.StartNew(()=>
            {
                while(true)
                {
                    if (token.IsCancellationRequested && threadToCancel!=null)
                    {
                        threadToCancel.Abort();
                        Console.WriteLine("Thread aborted");
                    }
                }
            });
            ///here 1000 can be replace by miliseconds after which you want to 
            // abort thread which calling your long running method 
            source.CancelAfter(1000);
            Console.ReadLine();   
        }
    }

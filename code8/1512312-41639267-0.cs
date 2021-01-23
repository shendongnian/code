        static void Main()
        {
            TaskScheduler.UnobservedTaskException += (object sender, UnobservedTaskExceptionEventArgs args) => { Console.WriteLine(args.Exception.InnerException.Message + " unobserved"); };
            try
            {
                ThrowExceptionInAsyncTask();
                Console.WriteLine("ThrowExceptionInAsyncTask not caught");
            }
            catch (Exception)
            {
                Console.WriteLine("ThrowExceptionInAsyncTask caught");
            }
            GC.Collect();
            try
            {
                ThrowExceptionInAsyncVoid();
                Console.WriteLine("ThrowExceptionInAsyncVoid not caught");
            }
            catch (Exception)
            {
                Console.WriteLine("ThrowExceptionInAsyncVoid caught");
            }
            GC.Collect();
        }
        static async Task ThrowExceptionInAsyncTask()
        {
            throw new InvalidOperationException("ThrowExceptionInAsyncTask");
        }
        static async void ThrowExceptionInAsyncVoid()
        {
            throw new InvalidOperationException("ThrowExceptionInAsyncVoid");
        }

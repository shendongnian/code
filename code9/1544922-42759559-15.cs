     private void expected()
     {
         Task task = Task.Run(() =>
         {
             Console.WriteLine("Before - running on task {0} {1}", 
                Task.CurrentId.HasValue ? Task.CurrentId.ToString() : "null",
                Environment.CurrentManagedThreadId);
             Task.Delay(TimeSpan.FromMilliseconds(100)).Wait();
             Console.WriteLine("After - running on task {0} {1}", 
                Task.CurrentId.HasValue ? Task.CurrentId.ToString() : "null",
                Environment.CurrentManagedThreadId);
         });
     }

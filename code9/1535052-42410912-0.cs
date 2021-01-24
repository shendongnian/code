     List<Task> tasks =  new List<Task>(); 
     for (int i = 0; i < 10; i++)
            {
                var i1 = i;
              tasks.Add(Task.Factory.StartNew(() => RequestHandle(i1.ToString())).ContinueWith(t => Console.WriteLine("Done"))); 
    
            }
        Task.WaitAll(tasks);

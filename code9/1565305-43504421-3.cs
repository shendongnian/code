      private static void Main(string[] args)
            {
                string outputFile = @"E:\output\file.txt";
                ConcurrentQueue<object> queue = new ConcurrentQueue<object>();
    
                string[] files = Directory.GetFiles(@"E:\100D3100\", "*.*", SearchOption.TopDirectoryOnly);
                bool isCompleted = false;
    
                Task t1 = new Task(() =>
                {
                    Parallel.ForEach(files, file =>
                        {
                            queue.Enqueue(file);
                        });
                    isCompleted = true;
                });
    
                t1.Start();
    
                Task t2 = new Task(() =>
                   {
                       object file = new object();
    
                       while (isCompleted != true)
                       {
                           queue.TryDequeue(out file);
                           if (file != null)
                           {
                               string[] text = File.ReadAllLines(file.ToString());
                               File.AppendAllLines(outputFile, text);
                           }
                       }
    
                       foreach (var item in queue)
                       {
                           string[] text = File.ReadAllLines(file.ToString());
                           File.AppendAllLines(outputFile, text);
                       }
                   });
    
                t2.Start();
    
                Task.WhenAll(t1, t2).Wait();
            }

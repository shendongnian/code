    private static void Main(string[] args)
            {
                string outputFile = @"E:\output\file.txt";
                ConcurrentQueue<object> queue = new ConcurrentQueue<object>();
    
                string[] files = Directory.GetFiles(@"E:\src");
                bool isCompleted = false;
    
                Task t1=new Task(() =>
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
                       while (isCompleted != true)
    
                           foreach (var item in queue)
                           {
                               string[] text = File.ReadAllLines(item.ToString());
                               File.AppendAllLines(outputFile, text);
                           }
                   });
    
           
                t2.Start();
    
                Task.WhenAll(t1, t2).Wait() ;
    
            }

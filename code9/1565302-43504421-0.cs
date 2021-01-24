     private static void Main(string[] args)
        {
            string outputFile = @"E:\output\file.txt";
            ConcurrentQueue<object> queue = new ConcurrentQueue<object>();
    
            string[] files = Directory.GetFiles(@"E:\src");
            bool isCompleted = false;
    
    
    
            var t1 = Task.Factory.StartNew(() =>
            {
                Parallel.ForEach(files, file =>
                    {
                        System.Threading.Thread.Sleep(1000);
                        queue.Enqueue(file); // change or insert your special sauce function here
                    });
                isCompleted = true;
            });
    
            var t2 = Task.Factory.StartNew(() =>
               {
                   while ((queue.Count > 0) && (isCompleted != true))
    
                       foreach (var item in queue)
                       {
                           string[] text = File.ReadAllLines(item.ToString());
                           File.AppendAllLines(outputFile, text);
                       }
               });
    
            Task.WaitAll(t1, t2);
        }

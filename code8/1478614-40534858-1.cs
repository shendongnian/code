    for (int i = 0; i < 2; i++)
    {
         var bw = new BackgroundWorker();
                
         // define the event handlers
         bw.DoWork += (sender, args) =>
         {
              // get the argument
              var value = args.Argument.ToString();
              Console.WriteLine("START Thread-------------");
              Console.WriteLine("Print:" + value);
         };
         bw.RunWorkerCompleted += (sender, args) =>
         {
             Console.WriteLine("END Thread-------------");
             if (args.Error != null)
             {
                 Console.WriteLine(args.Error.ToString());
             }
         };
         bw.RunWorkerAsync(i); // starts the thread with arguments
     }

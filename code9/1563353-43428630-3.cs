        static TaskFactory factory = new TaskFactory(new SequentialScheduler());
        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            factory.StartNew(() =>
            {
                Console.WriteLine("Writing to file " + DateTime.Now.ToString());
            });
            System.IO.File.AppendAllLines(@"C:\Temp\log.txt", 
             new[] { DateTime.Now.ToString()});
        }

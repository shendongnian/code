        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Writing to file " + DateTime.Now.ToString());
            });
            System.IO.File.AppendAllLines(@"C:\Temp\log.txt", 
              new[] { DateTime.Now.ToString()});
        }

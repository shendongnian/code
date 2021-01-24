        public static void Main()
        {
            var sw = new Stopwatch();
            sw.Start();
            while(sw.ElapsedMilliseconds < 150000)
            {
                //Do stuff for 150 seconds.
                Thread.Sleep(2000); //Wait 2 seconds before the next iteration/tick.
            }
            sw.Stop(); //150 seconds is over.
        }

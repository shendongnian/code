            Stopwatch clock = new Stopwatch();
            clock.Start();
            foreach (var item in myCol)
            {
                Hashtable ht = new Hashtable();
                //DoSomething()
            }
            clock.Stop();
            var tHash = clock.Elapsed;
            Stopwatch clock = new Stopwatch();
            clock.Start();
            foreach (var item in myCol)
            {
                Dictionary<,> dict = new Dictionary<,>();
                //DoSomething()
            }
            clock.Stop();
            Console.Write($"Delta t = {Math.Abs((tHash - clock.Elapsed).TotalMilliseconds)}"ms);

        private void Work1(string text)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            for (var i = 0; i < 100000000; i++)
            {
                 // real work here
            }
            _t1 = stopWatch.Elapsed.ToString();
        }
        private void Work2(string text)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            for (var i = 0; i < 100000000; i++)
            {
                 // real work here
            }
            _t2 = stopWatch.Elapsed.ToString();
        }

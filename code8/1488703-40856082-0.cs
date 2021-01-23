    class MyBusinessLayerClass
    {
        private StopWatch _stopWatch;
        public TimeSpan ElapsedTime
        {
            get { return _stopWatch.Elapsed; }
        }
    }

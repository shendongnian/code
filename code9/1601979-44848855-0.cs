    public class TimePredictor
    {
        private readonly Stopwatch watch = new Stopwatch();
        private long currentTime;
        private long currentProgress;
        public void Start() => watch.Restart();
        public void Stop() => watch.Stop();
        public double ElapsedTime => watch.ElapsedMilliseconds;
        public void Update(long progress)
        {
            currentTime = watch.ElapsedMilliseconds;
            currentProgress = progress;
        }
        public long GetExpectedTotalTime(long total)
            => currentProgress == 0 ? 0 : total * currentTime / currentProgress;
        public long GetExpectedTimeLeft(long total)
            => currentProgress == 0 ? 0 : GetExpectedTotalTime(total) - watch.ElapsedMilliseconds;
    }

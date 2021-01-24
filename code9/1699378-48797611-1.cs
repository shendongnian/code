    public class Runner
    {
        public Runner(string runner, TimeSpan time)
        {
            Runner = runner;
            Time = time;
        }
        public string Name { get; }
        public TimeSpan Time { get; }
    }

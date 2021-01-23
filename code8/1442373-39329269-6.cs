    public class State
    {
        public State()
            :this(0)
        { }
        private State(int count)
        {
            Count = count;
        }
        public int Count { get; private set; }
        public void IncrementCount() => Count++;
    }
    public static void Main(string[] args)
    {
        var state = new State();
        bool stop = false;
        var intervalCallback1 = new MultiIntervalTimerCallbackInfo(new System.Threading.TimerCallback(c =>
                                                                                                      {
                                                                                                          Console.WriteLine($"Interval 1: Call #{state.Count}. Thread Id: {Thread.CurrentThread.ManagedThreadId}");
                                                                                                          state.IncrementCount();
                                                                                                      }), state);
        var intervalCallback2 = new MultiIntervalTimerCallbackInfo(new System.Threading.TimerCallback(c =>
                                                                                                      {
                                                                                                          Console.WriteLine($"Interval 2: Call #{state.Count}. Thread Id: {Thread.CurrentThread.ManagedThreadId}");
                                                                                                          state.IncrementCount();
                                                                                                      }), state);
        var intervalCallback3 = new MultiIntervalTimerCallbackInfo(new System.Threading.TimerCallback(c =>
                                                                                                      {
                                                                                                          Console.WriteLine($"Interval 3: Call #{state.Count}. Thread Id: {Thread.CurrentThread.ManagedThreadId}");
                                                                                                          state.IncrementCount();
                                                                                                      }), state);
        var intervalCallback4 = new MultiIntervalTimerCallbackInfo(new System.Threading.TimerCallback(c =>
                                                                                                      {
                                                                                                          Console.WriteLine($"Interval 4: Call #{state.Count}.  Thread Id: {Thread.CurrentThread.ManagedThreadId}.\r\n Exiting loop", state);
                                                                                                          stop = true;
                                                                                                      }), state);
        var callbacks = new Dictionary<int, MultiIntervalTimerCallbackInfo>() { { 50, intervalCallback1 },
                                                                                { 100, intervalCallback2 },
                                                                                { 200, intervalCallback3  },
                                                                                { 2000, intervalCallback4 } };
        using (var timer = new MultiIntervalTimer(callbacks, 1000))
        {
            while (!stop)
            {
            }
        }
        Console.WriteLine($"Total calls: {state.Count}.");
        Console.ReadLine();
    }

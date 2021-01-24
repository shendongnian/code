    public class MyCustomStopWatch : Stopwatch
    {
    
            public DateTime? StartAt { get; private set; }
            public DateTime? EndAt { get; private set; }
    
            public void Reset()
            {
                StartAt = null;
                EndAt = null;
    
                base.Reset();
            }
    
            public void Restart()
            {
                StartAt = DateTime.Now;
                EndAt = null;
    
                base.Restart();
            }
    		
    		//This is what is important to you right now, to get data about that when you code started, and when your code finished with executing
    		public void Start()
            {
                StartAt = DateTime.Now;
    
                base.Start();
            }
    
            public void Stop()
            {
                EndAt = DateTime.Now;
    
                base.Stop();
            }
    		
    
     }

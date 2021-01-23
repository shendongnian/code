    public static class ProgramTimer
    {
        public static int resolution = 1000; //resolution of time needed in ms
        private static System.Diagnostics.Stopwatch stopwatch;
        private static System.Timers.Timer pollingTimer;
        private static System.TimeSpan lastMeasuredDebugTimespan;
        
        public static void Start()
        {
            pollingTimer = new System.Timers.Timer();
            pollingTimer.Interval = resolution;
            pollingTimer.Elapsed += timerEvent;
        }
    
        private static void timerEvent()
        {
            if (System.Diagnostics.Debugger.IsDebuggerAttached) {
                if (stopwatch == null) {
                    stopwatch = System.Diagnostics.Stopwatch.StartNew();
                }
            } else {
                if (stopwatch != null) {
                    stopwatch.Stop();
                    lastMeasuredDebugTime = stopwatch.Elapsed.TotalMilliseconds;
                    stopwatch = null;
                }
            }
        }
       
        public static System.TimeSpan getTimespanInDebug()
        {
            if (lastMeasuredDebugTimespan) {
                return lastMeasuredDebugTimespan;
            }
            return null;
        }
    }

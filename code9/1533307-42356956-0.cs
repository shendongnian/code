    public class TestClass {
        private static class TimerHandler
        {
            public static event TimerCallback TimerHandlers;
            private static readonly Timer timer = new Timer(TimerHandlerCallback, null, 0, 500);
            private static void TimerHandlerCallback(object state)
            {
                TimerHandlers?.Invoke(timer);
            }
        }
        public TestClass() {
            TimerHandler.TimerHandlers += DoStuff;
        }
    
        public void DoStuff(object source) {
        // Do stuff
        }
    }

    public class Test : IDisposable {
        protected readonly Timer Timer;
        protected int Count = 0;
        private bool disposed = false;
        public Test() {
            Timer = new Timer(Timer_Elapsed, new WeakReference<Test>(this), 0, 1000);
        }
        private static void Timer_Elapsed(object state) {
            var wr = (WeakReference<Test>) state;
            Test test;
            if (wr.TryGetTarget(out test)) {
                test.Count++;
                Console.WriteLine(test.Count);
            }
        }
        public void Dispose() // implementing IDisposable
        {
            if (!disposed) {
                Timer.Dispose();
                disposed = true;
            }
        }
    }

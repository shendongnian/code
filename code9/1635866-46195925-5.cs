    internal struct DownCounter {
        internal int value;
        public DownCounter(int initialValue) {
            value = initialValue;
        }
        public int Decrement() {
            return Interlocked.Decrement(ref value);
        }
    }
    unsafe class Program {
        static void Main(string[] args) {
            // the local stack allocated counter, to be shared by all threads
            DownCounter counter = new DownCounter(10);
            // some work for the threads
            Action<object> work = (c) => {
                double a = 1;
                for (int i = 0; i < 1 << 26; i++) {
                    // do stuff here 
                    a = a % i * a % (i + 1);
                }
                // decrement the main thread's stack counter
                int d = (*((DownCounter*)(IntPtr)c)).Decrement();
                Console.WriteLine($"Decremented: {d}");
            };
            // start 10 threads, each decrements the local, stack allocated(!) counter
            for (int i = 0; i < 10; i++) {
                Task.Factory.StartNew(work, (IntPtr)(&counter));
            }
            // poor mans 'spin wait' on the local counter
            while (counter.value > 0) {
                Thread.Sleep(100);
                Console.WriteLine($"# threads running: {counter.value}");
            }
            Console.Read();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (C1 instance = new C1())
            {
                Task.Factory.StartNew(() =>
                {
                    Task.Delay(1000);
                    bool disposed = (bool)typeof(C1).GetField("disposed", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(instance);
                    if (disposed)
                    {
                        Console.WriteLine("Already disposed will not call DoSomething()");
                    }
                    else
                    {
                        instance.DoSomething();
                    }
                });
            }
            Console.ReadKey(true);
        }
    }
    class C1 : IDisposable
    {
        bool disposed = false;
        public C1()
        {
        }
        public void DoSomething()
        {
            if (disposed)
                throw new ObjectDisposedException("C1");
            Console.WriteLine("Still existing!");
        }
        public void Dispose()
        {
            Dispose(true);
            Console.WriteLine("Disposed!");
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            disposed = true;
        }
    }

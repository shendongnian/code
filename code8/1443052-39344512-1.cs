    public class Test
    {
        static object _key = new object();
        public void First()
        {
            lock (_key)
            {
                Monitor.Wait(_key);
                Console.WriteLine("First");
                Monitor.Pulse(_key);
            }
        }
        public void Second()
        {
            lock (_key)
            {
                Console.WriteLine("Second");
                Monitor.Pulse(_key);
            }
        }
    }

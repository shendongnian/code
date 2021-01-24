    public class Data
    {
        private static object _padlock = new object();
        public void MethodA()
        {
            lock (_padlock)
            {
                Console.WriteLine("Start Method A");
                Console.WriteLine("End Method A");
            }
        }
        public void MethodB()
        {
            lock (_padlock)
            {
                Console.WriteLine("Start Method B");
                Console.WriteLine("End Method B");
            }
        }
    }

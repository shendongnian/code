    class Program
    {
        static WeakReference _ref;
        static void Main(string[] args)
        {
            Test();
            GC.Collect();
            Console.WriteLine(_ref.IsAlive); // false
        }
        static void Test()
        {
            var obj = new object();
            _ref = new WeakReference(obj);
            GC.Collect();
            Console.WriteLine(_ref.IsAlive); // true
        }
    }

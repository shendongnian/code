    class Test
    {
        public static WeakReference<Test> someInstance;
        public static void AliveTest()
        {
            Test t;
            if (someInstance == null) Console.WriteLine("Null");
            else Console.WriteLine(someInstance.TryGetTarget(out t));
        }
        public Test()
        {
            someInstance = new WeakReference<Test>(this);
            AliveTest();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            AliveTest();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();
            Test.AliveTest();
            Console.ReadLine();
        }
    }

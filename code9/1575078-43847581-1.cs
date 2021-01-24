    using System;
    namespace StackOverflow_Events
    {
        class Program
        {
            static void Main(string[] args)
            {
                C.Init();
                A.Test();
                Console.ReadKey();
            }
        }
        public delegate void TestDelegate();
        public class B
        {
            public static event TestDelegate TestEvent;
            public B()
            {
            }
            public void Fire()
            {
                TestEvent?.Invoke();
            }
        }
        public class A
        {
            public static void Test()
            {
                B b = new B();
                b.Fire(); 
            }
        }
        //Consumer application
        public class C
        {
            public static void Init()
            {
                B.TestEvent += new TestDelegate(c_TestEvent);
            }
            static void c_TestEvent()
            {
                Console.WriteLine("Console 2 Fired");
            }
        }
    }

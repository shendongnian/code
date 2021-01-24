    using System;
    namespace StackOverflow_Events
    {
        class Program
        {
            static void Main(string[] args)
            {
                B b = new B();
                A a = new A(b);
                C c = new C(b);
                a.Test();
                Console.ReadKey();
            }
        }
        public delegate void TestDelegate();
        public class B
        {
            public event TestDelegate TestEvent;
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
            private B b;
            public A(B _b)
            {
                b = _b;
            }
            public void Test()
            {
                b.Fire(); 
            }
        }
        //Consumer application
        public class C
        {
            private B b;
            public C(B _b)
            {
                b = _b;
                b.TestEvent += new TestDelegate(c_TestEvent);
            }
            static void c_TestEvent()
            {
                Console.WriteLine("Console 2 Fired");
            }
        }
    }

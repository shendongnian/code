    public class TestClass1
    {
        [Invoke]
        public void Method1()
        {
            Console.WriteLine("TestClass1->Method1");
        }
        [Invoke]
        public void Method2()
        {
            Console.WriteLine("TestClass1->Method2"););
        }
    }
    public class TestClass2
    {
        [Invoke]
        public void Method1()
        {
            Console.WriteLine("TestClass2->Method1");
        }
    }

    using System;
    public class A
    {
        public virtual void test()
        {
            Console.WriteLine("Class A");
        }
    }
    public class C
    {
        public void testSealFromOutsideClass()
        {
            B instanceB = new B();
            instanceB.test();
        }
    }
    public sealed class B : A
    {
        public override void test()
        {
            Console.WriteLine("Class B");
        }
        private void Privatemethod()
            {
            Console.WriteLine("Printing from a private method");
            }
    }
    //public class C : B {}
    public class TestSealedClass
    {
        public static void Main()
        {
            A a = new B();
            a.test();
           
            C c = new C();
             c.testSealFromOutsideClass();
            B b = new B();
            
            Console.Read();
        }
    }
}

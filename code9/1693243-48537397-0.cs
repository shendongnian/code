    public class A
    { 
        public A() : this(1)
        {     
            Console.WriteLine("Default constructor called");
        }
        public A(int a)
        {
            Console.WriteLine("Parametrised constructor called");
        }
    }

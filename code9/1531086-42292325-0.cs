    class Base
    {
        public delegate string Method();
        public Method m;
    }
    class Derived1 : Base
    {
        public string ParticularMethod()
        {
            return "Particular method of derived 1";
        }
    }
    class Derived2 : Base
    {
        public string ParticularMethod()
        {
            return "Particular method of derived 2";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Base obj; //it is just a declaring
            if (true)
            {
                obj = new Derived1();
                obj.m = (obj as Derived1).ParticularMethod;
            }
            else
            {
                obj = new Derived2();
                obj.m = (obj as Derived2).ParticularMethod;
            }
            Console.WriteLine(obj.m());
            //"Particular method of derived 1"
            Console.ReadKey();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Derived d = new Derived();
            Base b = d;
            Console.WriteLine($"b == d: {b == d}");
        }
    }
    class Base
    {
        public static bool operator ==(Base b1, Base b2)
        {
            return false;
        }
        public static bool operator !=(Base b1, Base b2)
        {
            return true;
        }
    }
    class Derived : Base
    {
        public static bool operator ==(Derived b1, Derived b2)
        {
            return true;
        }
        public static bool operator !=(Derived b1, Derived b2)
        {
            return false;
        }
    }

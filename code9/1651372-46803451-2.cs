    public class Addison
    {
        private object _value1;
        private object _value2;
        public Addision(object value1, object value2)
        {
             _value1 = value1;
             _value2 = value2;
        }
        public object Calculate()
        {
            return (double)_value1 + (double)_value2;
        }
    }
    class Program    
    {
        static void Main()
        {
            Addison addison = new Addison(4, 6);    //OBJ 1
            Addison addison2 = new Addison(4, 6); // OBJ 2
            Console.WriteLine(addison.Calculate());
            Console.WriteLine(addison2.Calculate());
            Console.ReadKey();
        }
    }

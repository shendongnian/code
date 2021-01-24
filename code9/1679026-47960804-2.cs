    public class ReverseClass
    {
        public Object Reverse(Object value)
        {
            string type = value.GetType().ToString();
    
            switch(type)
            {
                case "System.Int32":
                    return -(Int32)value;
                case "System.Boolean":
                    return !(bool)value;
            }
            return null;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            ReverseClass x = new ReverseClass();
    
            Console.WriteLine(x.Reverse(5));
            Console.WriteLine(x.Reverse(true));
        }
    }

    public class ReverseClass
    {
        const string INT_TYPE = "System.Int32";
        const string BOOL_TYPE = "System.Boolean";
        public Object Reverse(Object value)
        {
            string type = value.GetType().ToString();
    
            switch(type)
            {
                case INT_TYPE:
                    return -(Int32)value;
                case BOOL_TYPE:
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

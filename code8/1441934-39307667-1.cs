    public class Program
    {      
        public static void Main()
        {
            List<Derived> dlist = new List<Derived>();
            List<Base> bIEnum = dlist;
        }
    }

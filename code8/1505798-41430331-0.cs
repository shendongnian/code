    public class Myclass
    {
        public int someProp;
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Myclass m = new Myclass();
            Console.WriteLine(m.someProp);
            ChangeValue(m);
            Console.WriteLine(m.someProp);
            SetToNull(ref m);
            Console.WriteLine(m.someProp);
            Console.ReadKey();
        }
        static void ChangeValue(Myclass m)
        {
            m.someProp = 10;
        }
        static void SetToNull(ref Myclass m)
        {
            m = null;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Myclass m = new Myclass();
            SetToNull(ref m);
            if(m == null)
                Console.WriteLine("NULL!");
            Console.ReadKey();
        }
        static void SetToNull(ref Myclass m)
        {
            m = null;
        }
    }

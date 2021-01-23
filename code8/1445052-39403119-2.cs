    abstract public class test
    {
        abstract public void add(int a, int b);
    }
    class Program : test
    {
        public void add(decimal a, decimal b)
        {
            decimal c = a + b;
            Console.WriteLine("Decimal Addition : {0}", c);
        }
        public override void add(int a, int b)
        {
            int c = a + b;
            Console.WriteLine("Addition : {0} ", c);
        }
        static void Main(string[] args)
        {
            test obj = new Program();
            obj.add(10, 111);
            Console.ReadLine();
        }
    } 

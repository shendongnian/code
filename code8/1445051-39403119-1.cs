    abstract public class test
    {
        abstract public void add(int a, int b);
		
        abstract public void add(decimal a, decimal b);
    }
    public class Program : test
    {
        public override void add(int a, int b)
        {
            int c = a + b;
            Console.WriteLine("Addition : {0} ", c);
        }
	    public override void add(decimal a, decimal b)
        {
            decimal c = a + b;
            Console.WriteLine("Decimal Addition : {0}", c);
        }
        public static void Main(string[] args)
        {
            Program obj = new Program();
            obj.add((int)10, (int)111);
            Console.ReadLine();
        }
    }

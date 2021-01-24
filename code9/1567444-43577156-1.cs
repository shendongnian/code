    class Program
    {
        static void Main(string[] args)
        {
            Tuple<int, int> test = TupleTest().ToTuple();
    
        }
    
        static (int, int) TupleTest()
        {
            return (1, 2);
        }

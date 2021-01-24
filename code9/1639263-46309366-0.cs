    class Program
    {
        static void Main(string[] args)
        {
            var pos = 5m;
            var zero = 0m;
            var neg = -5m;
    
            var format = "+$0.00;-$0.00;$0.00";
    
            Console.WriteLine(pos.ToString(format));
            Console.WriteLine(zero.ToString(format));
            Console.WriteLine(neg.ToString(format));
        }
    }

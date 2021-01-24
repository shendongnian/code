    public abstract class IsAbstract
    {
        public abstract void PrintOut();
    }
    
    class Program : IsAbstract
    {
        static void Main(string[] args)
        {
            var p = new Program();
            p.PrintOut();
        }
    
        public override void PrintOut()
        {
            Console.WriteLine(nameof(IsAbstract));
        }
    }

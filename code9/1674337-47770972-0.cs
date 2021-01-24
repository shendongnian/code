    public class NotAbstract
    {
        public void PrintOut()
        {
            Console.WriteLine(nameof(NotAbstract));
        }
    }
    
    class Program : NotAbstract
    {
        static void Main(string[] args)
        {
            var p = new Program();
            p.PrintOut();
        }
    }

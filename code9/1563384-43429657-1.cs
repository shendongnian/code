    class Program
    {
        static void Main(string[] args)
        {
            A a;
            //a.X = 1; <------ SEE this is commented out
            a.Print();
            Console.Read();
        }
    }
    struct A
    {
        public int X;
        public void Print()
        {
            Console.WriteLine("A has X: {0}", this.X);
        }
    }

    static void Main(string[] args)
    {
        using (myFunction())
        {
            myClass.LastInstance.Process();
        }
        Console.ReadLine();
    }
    static myClass myFunction()
    {
        return new myClass();
    }
    class myClass : IDisposable
    {
        public static myClass LastInstance;
        public myClass() 
        { 
            Console.WriteLine("constructor");
            LastInstance = this;
        }
        public void Dispose() { Console.WriteLine("dispose"); }
        public void Process() { Console.WriteLine("process"); }
    }

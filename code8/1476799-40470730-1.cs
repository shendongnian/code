    class GenericPrinter<T>
    {
        public virtual void Print()
        {
            Console.WriteLine("Unspecialized method");
        }
    }
    class GenericPrinterInt : GenericPrinter<int>
    {
        public override void Print()
        {
            Console.WriteLine("Specialized with int");
        }
    }

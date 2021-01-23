    class GenericPrinter<T>
    {
        public virtual void Print()
        {
            Console.WriteLine("Unspecialized method");
        }
    }
    class IntPrinter : GenericPrinter<int>
    {
        public override void Print()
        {
             Console.WriteLine("Specialized with int");
        }
    }

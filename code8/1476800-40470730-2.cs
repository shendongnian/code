    class GenericPrinter<T>
    {
        public static GenericPrinter<T> Create()
        {
            if (typeof(int).IsAssignableFrom(typeof(T)))
                return (GenericPrinter<T>)(object)new GenericPrinterInt();
            if (typeof(double).IsAssignableFrom(typeof(T)))
                return (GenericPrinter<T>)(object)new GenericPrinterDouble();
            // Other types to check ...
            return new GenericPrinter<T>();
        }
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
    class GenericPrinterDouble : GenericPrinter<double>
    {
        public override void Print()
        {
            Console.WriteLine("Specialized with double");
        }
    }

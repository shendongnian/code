    class Program
    {
    
        static void Main()
        {
            var genericsExample = new GenericsExample<bool>();
            genericsExample.Value = true;
            Console.WriteLine("Value is " + genericsExample.Value);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double val = 55.30000000000000004;
            string strVal=val.ToString("0.0");
            Console.WriteLine("Formatted value (a): " + strVal);
            Console.WriteLine(String.Format("Formatted value (b): {0:0.0}", val));
            Console.ReadKey();
        }
    }

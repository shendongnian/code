    public static class Program
    {
        public static void Main()
        {
            string s = "1";
            double d = Convert<string, double>(s);
            Console.WriteLine(d);
        }
        public static TOut Convert<TIn, TOut>(TIn text)
        {
            return (TOut)System.Convert.ChangeType(text, typeof(TOut));
        }
    }

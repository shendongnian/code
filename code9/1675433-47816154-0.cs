    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = new[] { 1, 2, 3 };
    
            var (first, second, rest) = ints.Destruct2();
        }
    }
    
    public static class Extensions
    {
        public static (T first, T[] rest) Desctruct1<T>(this T[] items)
        {
            return (items[0], items.Skip(1).ToArray());
        }
    
        public static (T first, T second, T[] rest) Destruct2<T>(this T[] items)
        {
            return (items[0], items[1], items.Skip(2).ToArray());
        }
    }

    class Program
    {
        private static int[] intArray = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    
        static void Main(string[] args)
        {
            var rangeVals = intArray.GetValueRange(3, 8);
    
            Console.WriteLine(string.Join(",", rangeVals.Select(i => $"{i}")));
            Console.ReadKey();
        }
    }
    
    public static class Extensions
    {
        public static IEnumerable<int> GetValueRange(this IEnumerable<int> source, int lower, int upper) {
            return source.SkipWhile(i => i < lower).TakeWhile(i => i <= upper);
        }
        
    }

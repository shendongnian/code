    public static class Program
    {
        static void Main(string[] args)
        {
            var ranks = Enum.GetValues(typeof(Rank)).Cast<Rank>();
            Console.WriteLine("Test rank with unique values:");
            foreach (Rank rank in ranks)
            {
                Console.WriteLine($"  ToString()={rank,-5}, (int)={(int)rank, 2}, GetNumericValue()={rank.GetNumericValue(), 2}");
            }
        }

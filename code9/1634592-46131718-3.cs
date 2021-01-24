    public static class Program
    {
        static void Main(string[] args)
        {
            Rank[] ranks = GetEnumValues<Rank>();
            Console.WriteLine("Test rank with unique values:");
            foreach (Rank rank in ranks)
            {
                Console.WriteLine($"  ToString()={rank}, (int)={(int)rank}, GetNumericValue()={rank.GetNumericValue()}");
            }
        }

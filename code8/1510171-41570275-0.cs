    class Program
    {
        static void Main(string[] args)
        {
            int intBorder = 1900;
            int intN = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < intBorder; i++)
            {
                Storer.Store(Console.ReadLine().Split());
            }
        }
        static class Storer
        {
            public static readonly List<int> listPoints = new List<int>();
            public static readonly List<int> listRanks = new List<int>();
            public static void Store(string[]data)
            {
                listPoints.Add(int.Parse(data[0]));
                listRanks.Add(int.Parse(data[1]));
            }
        }
    }

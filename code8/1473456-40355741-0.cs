    enum City
    {
        Boston,
        Chicago,
        Dallas,
        LasVegas,
    }
    static class CityDistance
    {
        private static int[][] _distances =
        {
            new [] { 1004, 1753, 2752 },
            new [] { 921, 1780 },
            new [] { 1230 },
        };
        public static int GetDistance(City city1, City city2)
        {
            if (city1 == city2)
            {
                return 0;
            }
            if (city1 > city2)
            {
                City cityT = city1;
                city1 = city2;
                city2 = cityT;
            }
            int cityIndex1 = (int)city1, cityIndex2 = (int)city2 - (cityIndex1 + 1);
            return _distances[cityIndex1][cityIndex2];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            foreach (City city1 in Enum.GetValues(typeof(City)))
            {
                foreach (City city2 in Enum.GetValues(typeof(City)))
                {
                    Console.Write("{0,4}   ", CityDistance.GetDistance(city1, city2));
                }
                Console.WriteLine();
            }
        }
    }

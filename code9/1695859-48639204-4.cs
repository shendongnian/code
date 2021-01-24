    public class PeriodComparer : IComparer<string>
    {
        int num = 0;
        public int Compare(string x, string y)
        {
            if (++num >= 100000)
            {
                Console.WriteLine(num);
            }
            var year1 = int.Parse(x.Substring(2));
            var year2 = int.Parse(y.Substring(2));
            if (year1 < year2)
                return -1;
            if (year1 > year2)
                return 1;
            var season1 = x.Substring(0, 2);
            var season2 = y.Substring(0, 2);
            if (season1 == "VT" && season2 != "VT")
                return -1;
            if (season2 == "VT" && season1 != "VT")
                return 1;
            return StringComparer.InvariantCulture.Compare(season1, season2);
        }
    }

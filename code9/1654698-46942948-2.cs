    public static class Ext {
        static double ValuePreservingAdd(double a, double b)  => double.IsNaN(a) ? b : double.IsNaN(b) ? a : a + b;
        public static double ValuePreservingSum(this IEnumerable<double> src) => src.Aggregate(double.NaN, (a, b) => ValuePreservingAdd(a, b));
        public static double ValuePreservingSum<T>(this IEnumerable<T> src, Func<T, double> select) => src.Select(s => select(s)).Aggregate(double.NaN, (a, b) => ValuePreservingAdd(a, b));
    }
    var ans = offers.GroupBy(o => new { o.TradingDate, o.HourOfDay }, o => o.OfferBands)
                    .OrderBy(obg => obg.Key.TradingDate).ThenBy(obg => obg.Key.HourOfDay)
                    .Select(obg => obg.SelectMany(ob => ob).Where(filter).ValuePreservingSum(b => b.Quantity));

    internal static class Extensions
    {
        public static IEnumerable<dynamic> Transform(this IEnumerable<ChartSeries> data)
        {
            foreach (var chartSeries in data)
            {
                var result = new ExpandoObject() as IDictionary<string, object>;
                result.Add(chartSeries.Person, chartSeries.Percent);
                yield return result;
            }
        }
    }

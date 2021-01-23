    public static IEnumerable<Tuple<double,double>> ParseCoordinates(this IEnumerable<string> points, IFormatProvider formatProvider)
    {
        foreach (var point in points)
        {
            var coordinates = point.Split(';');
            double x = 0;
            double y = 0;
            if (!double.TryParse(coordinates[0], NumberStyles.Number, formatProvider, out x))
            {
                x = double.NaN;
            }
            if (!double.TryParse(coordinates[1], NumberStyles.Number, formatProvider, out y))
            {
                y = double.NaN;
            }
            yield return new Tuple<double, double>(x, y);
        }
    }

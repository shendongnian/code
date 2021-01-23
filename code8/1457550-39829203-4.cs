    public static class Helper
    {
        public static List<double[]> MyFilter(this List<double[]> list, int tolerance)
        {
            var result = list
                .Select(arr =>
                {
                    // rounds numbers with precision that is set in tolerance variable
                    arr = arr.Select(d => d = Math.Round(d, tolerance)).ToArray();
                    return arr;
                }).Distinct(new MyDoubleArrComparer()) // here we use our custom comparer
                .ToList();
            return result;
        }
    }

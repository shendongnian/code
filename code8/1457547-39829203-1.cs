    public static class Helper
    {
        public static List<double[]> MyFilter(this List<double[]> list, int tolerance)
        {
            var result = list
                .Select(arr =>
                {
                    arr = arr.Select(d => d = Math.Round(d, tolerance)).ToArray();
                    return arr;
                }).Distinct(new MyDoubleArrComparer())
                .ToList();
            return result;
        }
    }

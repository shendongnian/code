    public static class MyExtensionMethods
    {
        public static Double SumX(this IEnumerable<Double> list)
        {
            Double sum = 0;
            foreach (Double number in list)
            {
                sum += number;
            }
            return sum;
        }
    }

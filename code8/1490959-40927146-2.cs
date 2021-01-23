    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                calculate();
            }
        }
        private static void calculate()
        {
            List<Double> numbers = new List<Double>();
            Double[] sums1 = new Double[1000];
            Double[] sums2 = new Double[1000];
            for (int i = 0; i < 1000; i++)
            {
                numbers.Add(i * i);
            }
            
            Int64 startTime1 = Stopwatch.GetTimestamp();
            for (int i = 0; i < 1000; i++)
            {
                sums1[i] = withIEnumerable(numbers);
            }
            Int64 endTime1 = Stopwatch.GetTimestamp();
            Int64 startTime2 = Stopwatch.GetTimestamp();
            for (int i = 0; i < 1000; i++)
            {
                sums2[i] = withList(numbers);
            }
            Int64 endTime2 = Stopwatch.GetTimestamp();
            
            Console.WriteLine("withIEnumerable.    Start = {0}, End = {1}: Diff = {2}", startTime1, endTime1, endTime1 - startTime1);
            Console.WriteLine("withList. Start = {0}, End = {1}: Diff = {2}", startTime2, endTime2, endTime2 - startTime2);
        }
        private static double withIEnumerable(IEnumerable<double> numbers)
        {
            double sum = 0;
            foreach (Double number in numbers)
            {
                sum += number;
            }
            return sum;
        }
        private static double withList(List<double> numbers)
        {
            double sum = 0;
            foreach (Double number in numbers)
            {
                sum += number;
            }
            return sum;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numElements = 100000;
            int numArrays = 10000;
            double[][] sets = new double[numArrays][];
            using (Timer("Generating Data"))
            {
                for (int i = 0; i < numArrays; i++)
                {
                    sets[i] = GetRandomDoubles(numElements, randomSeed: i);
                }
            }
            int period = 14;
            using (Timer("CPU Single Thread"))
            {
                CalculateCPU(sets, period);
            }
            using (Timer("CPU Parallel"))
            {
                CalculateCPUParallel(sets, period);
            }
            Console.WriteLine("Finished");
            Console.ReadKey();
        }
        public static IDisposable Timer(string name)
        {
            return new SWTimer(name);
        }
        public class SWTimer : IDisposable
        {
            private Stopwatch _sw;
            private string _name;
            public SWTimer(string name)
            {
                _name = name;
                _sw = Stopwatch.StartNew();
            }
            public void Dispose()
            {
                _sw.Stop();
                Console.WriteLine("Task " + _name + ": " + _sw.Elapsed.TotalMilliseconds + "ms");
            }
        }
        public static void CalculateCPU(double[][] arrays, int period)
        {
            foreach(var arr in arrays)
            {
                Calculate(arr, period);
            }
        }
        public static void CalculateCPUParallel(double[][] arrays, int period)
        {
            Parallel.ForEach(arrays, arr =>
            {
                Calculate(arr, period);
            });
        }
        public static double[] Calculate(double[] num, int period)
        {
            var final = new double[num.Length];
            double sum = num[0];
            double coeff = 2.0 / (1.0 + period);
            for (int i = 0; i < num.Length; i++)
            {
                sum += coeff * (num[i] - sum);
                final[i] = sum;
            }
            return final;
        }
        static double[] GetRandomDoubles(int num, int randomSeed)
        {
            Random r = new Random(randomSeed);
            var res = new double[num];
            for (int i = 0; i < num; i++)
                res[i] = r.NextDouble() * 0.9 + 0.05;
            return res;
        }
        
    }

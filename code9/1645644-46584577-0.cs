    public class WeightedChanceParam
    {
        public Action Func { get; }
        public double Ratio { get; }
        public WeightedChanceParam(Action func, double ratio)
        {
            Func = func;
            Ratio = ratio;
        }
    }
    public class WeightedChanceExecutor
    {
        public WeightedChanceParam[] Parameters { get; }
        private Random r;
        public double RatioSum
        {
            get { return Parameters.Sum(p => p.Ratio); }
        }
        public WeightedChanceExecutor(params WeightedChanceParam[] parameters)
        {
            Parameters = parameters;
            r = new Random();
        }
        public void Execute()
        {
            double numericValue = r.NextDouble() * RatioSum;
            foreach (var parameter in Parameters)
            {
                numericValue -= parameter.Ratio;
                if (!(numericValue <= 0))
                    continue;
                parameter.Func();
                return;
            }
        }
    }

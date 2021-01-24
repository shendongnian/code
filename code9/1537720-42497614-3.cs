    class DoubleReader
    {
        public void PopulateFunctionDoubleIncr(double[] data)
        {
            int idx = 0;
            while (idx < data.Length)
            {
                data[idx] = (double)idx;
                ++idx;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var data = new double[1000];
            DoubleReader dr = new DoubleReader();
            My.PopFunctionDoubleDelegate func = dr.PopulateFunctionDoubleIncr;
            My.add_cli(data, func);
        }
    }

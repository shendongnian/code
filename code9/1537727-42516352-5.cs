    class DoubleReader
    {
        public DoubleReader() { }
    
        public void PopulateFunctionDoubleIncr(My.DoubleArray data)
        {
            int idx = 0;
            while (idx < data.Length)
            {
                data.SetValue(idx, (double)idx);
                ++idx;
            }
        }
    
        static void Main(string[] args)
        {
            DoubleReader dr = new DoubleReader();
            My.PopFunctionDoubleDelegate func = dr.PopulateFunctionDoubleIncr;
            My.ProcessDoubleCLI.add_cli(func);
        }
    }

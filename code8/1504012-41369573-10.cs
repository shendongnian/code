    class Program
    {
        // In some class who knows where...
        static bool Method1(Tuple<int, int> range, int input)
        {
            return true;
        }
        static bool Method2(Tuple<int, int> range, int input)
        {
            return true;
        }
        static bool Method3(Tuple<int, int> range, int input)
        {
            return true;
        }
        static void Main(string[] args)
        {
            RangeOperationManager rangeProcessor = new RangeOperationManager();
            rangeProcessor.AddOperation(10000, 25000, Method1);
            rangeProcessor.AddOperation(30000, 80000, Method2);
            rangeProcessor.AddOperation(85000, 90000, Method3);
            bool result1 = rangeProcessor.Operate(12300); // true
            bool result2 = rangeProcessor.Operate(35000); // true
            bool result3 = rangeProcessor.Operate(89000); // true
        }
    }

    static class Program
    {
        private static void Main(string[] args)
        {
            var assertions = new List<Func<object[], bool>>
            {
                Assertion1,
                Assertion2,
                Assertion3
            };
            var yourResult = Assert(assertions, 1, "1", true);
            Console.WriteLine(yourResult); // returns "True" in this case
            Console.ReadLine();
        }
        private static bool Assert(IEnumerable<Func<object[], bool>> assertions, params object[] args)
        {
            // the same as
            // return assertions.Aggregate(true, (current, assertion) => current & assertion(args));
            var result = true;
            foreach (var assertion in assertions)
                result = result & assertion(args);
            return result;
        }
        private static bool Assertion1(params object[] args)
        {
            return Convert.ToInt32(args[0]) == 1;
        }
        private static bool Assertion2(params object[] args)
        {
            return Convert.ToInt32(args[0]) == Convert.ToInt32(args[1]);
        }
        private static bool Assertion3(params object[] args)
        {
            return Convert.ToBoolean(args[2]);
        }
    }

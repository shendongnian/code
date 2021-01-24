    class Program
    {
        public static void someFunction1()
        {
            Console.WriteLine("1");
        }
        public static void someFunction2()
        {
            Console.WriteLine("2");
        }
        static void Main(string[] args)
        {
            var functionList = new System.Collections.Generic.Dictionary<string, System.Delegate>() {
                { nameof(someFunction1), new Action(() => someFunction1()) },
                { nameof(someFunction2), new Action(() => someFunction2()) },
            };
            string callNameBase = "someFunction";
            for (int i = 1; i <= 2; i++)
            {
                string callName = callNameBase + i.ToString();
                functionList[callName].DynamicInvoke();
            }
            Console.ReadLine();
        }
    }

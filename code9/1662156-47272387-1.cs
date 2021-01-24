        static void Main(string[] args)
        {
            PrintTest(() => DelegateTest("Hello"));
        }
        public static void DelegateTest(string test)
        {
            Console.WriteLine(test);
            throw new ArgumentException();
        }
        public static void PrintTest(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception w)
            {
                throw;
            }
        }

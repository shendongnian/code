    public class so40645583
    {
        private IList<Delegate> FuncList = new List<Delegate>();
        public void Add<InputType, OutputType>(Func<InputType, OutputType> func)
        {
            FuncList.Add(func);
        }
        public void Add<InT1, InT2, OutputType>(Func<InT1, InT2, OutputType> func)
        {
            FuncList.Add(func);
        }
        public void Add<InT1, InT2, InT3, OutputType>(Func<InT1, InT2, InT3, OutputType> func)
        {
            FuncList.Add(func);
        }
        public void Add<InT1, InT2, InT3, InT4, OutputType>(Func<InT1, InT2, InT3, InT4, OutputType> func)
        {
            FuncList.Add(func);
        }
        // This won't work as it is trying to return a delegate type
        // public static Func<int, double, char, string, string> SomeFunc(int i, double d, char c, string s1)
        public static string SomeFunc(int i, double d, char c, string s1)
        {
            return String.Format("{0} {1} {2} {3}", i, d, c, s1);
        }
        public static string SomeFunc2(int i)
        {
            return i.ToString();
        }
        public void Test()
        {
            Add<int, double, char, string, string>(SomeFunc);
            Add<int, string>(SomeFunc2);
            // Try invoking via list
            Delegate d = FuncList[0];
            string s = (string)d.DynamicInvoke(2, 2.0, 'c', "Hi");
            Console.WriteLine(s);
            // Invoke directly
            s = SomeFunc(2, 2.0, 'c', "Hi");
            Console.WriteLine(s);
            // Now the second one
            d = FuncList[1];
            s = (string)d.DynamicInvoke(5);
            Console.WriteLine(s);
        }
    }

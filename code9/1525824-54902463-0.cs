    class Program
    {
        public static void Main()
        {
            typeof(Program).
                GetMethod("Main", System.Reflection.BindingFlags.Static).
                Invoke(null, new object[] { });
        }
    }

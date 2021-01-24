    public class Class1
    {
        private const int ConstantInt = 42;
        private static readonly int StaticInt = 42;
        static Class1()
        {
            StaticInt = -20;
        }
        public void DemoMethod(ref uint referenceValue)
        {
            referenceValue = StaticInt; // it's -20
        }
    }

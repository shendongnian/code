    public static class MyClassAccessor
    {
        public static readonly Func<MyClass, int> GetMyProperty;
        public static readonly Action<MyClass, int> SetMyProperty;
        static MyClassAccessor()
        {
            var prop = typeof(MyClass).GetProperty("MyProperty", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            GetMyProperty = (Func<MyClass, int>)Delegate.CreateDelegate(typeof(Func<MyClass, int>), prop.GetMethod);
            SetMyProperty = (Action<MyClass, int>)Delegate.CreateDelegate(typeof(Action<MyClass, int>), prop.SetMethod);
        }
    }

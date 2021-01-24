    class C
    {
        protected static List<Type> _types = new List<Type>();
        public static void ReportCounts()
        {
            foreach (Type type in _types)
            {
                FieldInfo fi = type.GetField("_count", BindingFlags.Static | BindingFlags.NonPublic);
                Console.WriteLine($"{type.Name}: {fi.GetValue(null)}");
            }
        }
    }
    class C<T> : C
    {
        static int _count;
        static C()
        {
            _types.Add(typeof(C<T>));
        }
        public void M()
        {
            _count++;
        }
    }

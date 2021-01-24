    class C
    {
        protected static List<Func<(Type, Dictionary<string, int>)>>
            _countFieldAccessors = new List<Func<(Type, Dictionary<string, int>)>>();
        protected static void _AddType(Func<(Type, Dictionary<string, int>)> fieldAccess)
        {
            _countFieldAccessors.Add(fieldAccess);
        }
        public static void ReportCounts()
        {
            foreach (Func<(Type, Dictionary<string, int>)> fieldAccess in _countFieldAccessors)
            {
                var (type, counts) = fieldAccess();
                foreach (var kvp in counts)
                {
                    Console.WriteLine($"{type.GetFriendlyName()}.{kvp.Key}: {kvp.Value}");
                }
            }
        }
    }
    class C<T> : C
    {
        static Dictionary<string, int> _counts = new Dictionary<string, int>();
        static void _Increment(string name)
        {
            int count;
            _counts.TryGetValue(name, out count);
            _counts[name] = count + 1;
        }
        static C()
        {
            _AddType(() => (typeof(C<T>), _counts));
        }
        public void M1()
        {
            _Increment(nameof(M1));
        }
        public void M2()
        {
            _Increment(nameof(M2));
        }
    }
    static class Extensions
    {
        public static string GetFriendlyName(this Type type)
        {
            return type.IsGenericType ?
                $"{type.Name.Substring(0, type.Name.IndexOf('`'))}<{string.Join(",", type.GetGenericArguments().Select(t => t.Name))}>" :
                type.Name;
        }
    }

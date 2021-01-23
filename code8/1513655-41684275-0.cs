    class Program
    {
        static void Main(string[] args)
        {
                var x = new Struct1() { A = 0, B = -10 };
                var y = new Struct2() { C = 0, D = -10 };
                MyFunction(ref x);
                MyFunction(ref y);
        }
        public static void EditStruct(ref Struct1 structToEdit)
        {
            structToEdit = new Struct1() { A = 10, B = 20 };
        }
        public static void EditStruct(ref Struct2 structToEdit)
        {
            structToEdit = new Struct2() { C = 30, D = 40 };
        }
        private delegate void EditDelegate<T>(ref T obj);
        public static void MyFunction<T>(ref T unknownStruct)
        {
            Delegate d;
            if (!_dict.TryGetValue(typeof(T), out d))
            {
                d = typeof(Program).Assembly.GetTypes()
                    .SelectMany(x => x.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                    .Single(x => x.Name == "EditStruct" && x.GetParameters().SingleOrDefault(y => y.ParameterType.Equals(typeof(T).MakeByRefType())) != null)
                    .CreateDelegate(typeof(EditDelegate<T>));
                _dict.Add(typeof(T), d);
            }
            (d as EditDelegate<T>)(ref unknownStruct);
        }
        private static readonly Dictionary<Type, Delegate> _dict = new Dictionary<Type, Delegate>(new TypeComparer());
        class TypeComparer : IEqualityComparer<Type>
        {
            public bool Equals(Type x, Type y) => x.Equals(y);
            public int GetHashCode(Type obj) => obj.GetHashCode();
        }
    }
    public struct Struct1
    {
        public int A;
        public int B;
    }
    public struct Struct2
    {
        public int C;
        public int D;
    }

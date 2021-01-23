        public static class StringToTypeMapExtensions
        {
            public static void Add<T>(this StringToTypeMap map, T prototype)
            {
                map.Add(typeof(T).Name, typeof(T));
            }
        }
        public class StringToTypeMap : Dictionary<string, Type>
        {
        }
        public class Foo { }
        public class Bar { }
        public class Baz { }

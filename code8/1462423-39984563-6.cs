        public static class StringToTypeMapExtensions
        {
            public static void Add<T>(this StringToTypeMap map, T prototype)
                where T : SomeBase
            {
                map.Add(typeof(T).Name, typeof(T));
            }
        }
        public class StringToTypeMap : Dictionary<string, Type>
        {
        }
        public class SomeBase { }
        public class Foo : SomeBase { }
        public class Bar : SomeBase { }
        public class Baz : Bar { }
        public class Alien { }

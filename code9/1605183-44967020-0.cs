    public class Foo
    {
        public static void OpTest_1<T>(T s, T t) where T : class
        {
            var val = s == t;
        }
        public static void OpTest_2(string s, string t)
        {
            var val = s == t;
        }
        // Does not compile.
        //public static void OpTest_3<T>(T s, T t) where T : struct
        //{
        //    var val = s == t;
        //}
    }

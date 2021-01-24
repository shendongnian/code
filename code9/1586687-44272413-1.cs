    using static Prelude;
    public class CurryTest
    {
        public void Test()
        {
            var f = curry<int, int, int>(MyTools.MyMethod<int, int, int>);
            var c = f(1)(2);
        }
    }

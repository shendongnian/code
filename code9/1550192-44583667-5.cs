    internal static class GetValueImpl<R, S>
    {
        private static T DefImpl<T>(R r, S s) => default(T);
        private static int IntRet(R r, S s) => int.MaxValue;
        internal static class Specializer<T>
        {
            internal static Func<R, S, T> Fun;
            internal static T Call(R r, S s) => null != Fun ? Fun(r, s) : DefImpl<T>(r, s);
        }
        static GetValueImpl()
        {
            Specializer<int>.Fun = IntRet;
        }
    }
    public class TestClass
    {
        //R and S are not specialized, we are specializing T
        public T GetValue<R, S, T>(R r, S s) => GetValueImpl<R, S>.Specializer<T>.Call(r, s);
    }

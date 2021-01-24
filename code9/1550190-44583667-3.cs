    internal static class IndexerImpl
    {
        private static T IndexerDefaultImpl<T>(int i) => default(T); //default implementation
        private static T IndexerImpl2<T>(int i) => default(T); //another implementation for short/int/long
        private static string IndexerForString(int i) => (i * i).ToString(); //specialization for T=string
        private static DateTime IndexerForDateTime(int i) => new DateTime(i * i * i); //specialization for T=DateTime
        static IndexerImpl() //install the specializations
        {
            Specializer<string>.Fun = IndexerForString;
            Specializer<DateTime>.Fun = IndexerForDateTime;
            Specializer<short>.Fun = IndexerImpl2<short>;
            Specializer<int>.Fun = IndexerImpl2<int>;
            Specializer<long>.Fun = IndexerImpl2<long>;
        }
        internal static class Specializer<T> //specialization dispatcher
        {
            internal static Func<int, T> Fun;
            internal static T Call(int i)
                => null != Fun
                    ? Fun(i)
                    : IndexerDefaultImpl<T>(i);
        }
    }
    public class YourClass<T>
    {
        public T this[int i] => IndexerImpl.Specializer<T>.Call(i);
    }

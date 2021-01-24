    internal static class IndexerImpl //the helper class
    {
        private static T IndexerDefaultImpl<T>(int i) => default(T); //default implementation
        private static string IndexerForString(int i) => (i * i).ToString(); //specialization for T=string
        private static DateTime IndexerForDateTime(int i) => new DateTime(i * i * i); //specialization for T=DateTime
        static IndexerImpl() //install specializations
        {
            Specializer<string>.Fun = IndexerForString;
            Specializer<DateTime>.Fun = IndexerForDateTime;
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

    public class Collection<T>: IList<T>, IList, IReadOnlyList<T>
    {
        IList<T> items;
        [NonSerialized]
        private Object _syncRoot;
 
        public Collection() {
            items = new List<T>();
        }
 
        public Collection(IList<T> list) {
            if (list == null) {
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.list);
            }
            items = list;
        }

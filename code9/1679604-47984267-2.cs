    public static class EnumerableOnceExt {
        public static EnumerableOnce<IEnumerable<T>, T> EnumerableOnce<T>(this IEnumerable<T> src) => new EnumerableOnce<IEnumerable<T>, T>(src);
    }
    
    public class EnumerableOnce<T, V> : IEnumerable<V> where T : IEnumerable<V> {
        IEnumerator<V> srcEnum;
    
        public EnumerableOnce(T src) {
            srcEnum = src.GetEnumerator();
        }
    
        public IEnumerator<V> GetEnumerator() {
            return srcEnum;
        }
    
        IEnumerator IEnumerable.GetEnumerator() {
            return srcEnum;
        }
    }

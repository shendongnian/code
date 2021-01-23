    namespace My.Company { // OR namespace My {
        public static class OtherLinqExtensions {
            public static IEnumerable<T> Select<T, TResult>(this IEnumerable<T> items, Func<T, TResult> selector) {
                // do your stuff
            }
        }
    }

    public static class Extensions {
        public static T NextValue<T>(this IEnumerator<T> enumerator) {
            enumerator.MoveNext();
            return enumerator.Current;
        }
    }

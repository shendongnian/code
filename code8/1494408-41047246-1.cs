    public static class Extensions {
        public static TResult Select<T, TResult>(this T target, Func<T, TResult> selector) {
            return selector(target);
        }
    }

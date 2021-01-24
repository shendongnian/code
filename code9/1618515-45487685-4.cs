    public static class TransformExtension
    {
        public static T2 Transform<T1, T2>(this T1 t1, Func<T1, T2> transform)
        {
            return transform(t1);
        }
    }

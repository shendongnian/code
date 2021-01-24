    public static class Check<T>
    {
        public static readonly Func<T, bool> IsNull =
            typeof(T).IsValueType ? new Func<T, bool>(o => false) : o => o == null;
    }

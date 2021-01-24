    public static class CoalescingExtensions
    {
        public static T IfDefault<T> (this T value, T valueIfDefault)
        {
            return value.Equals(default(T)) ? valueIfDefault: value;
        }
    }

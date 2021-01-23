    public static class Extensions
    {
        public static Validator<T, TKey> GetValidatorFor<T, TKey>(this List<T> list, Func<T, TKey> getter) where T : class
        {
            return new Validator<T, TKey>(getter);
        }
    }

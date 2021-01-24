    public static class EnumerableHelper
    {
        public static IEnumerable<TEnum> RangeToInc<TEnum>(this TEnum from, TEnum to)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var cmp = Comparer<TEnum>.Default;
            while (cmp.Compare(from, to) <= 0)
            {
                yield return from;
                from = EnumerableHelperImpl<TEnum>.Increment(from);
            }
        }
        private static class EnumerableHelperImpl<TEnum>
        {
            public static readonly Func<TEnum, TEnum> Increment;
            static EnumerableHelperImpl()
            {
                var par = Expression.Parameter(typeof(TEnum));
                Expression body = typeof(TEnum).IsEnum ?
                    Expression.Convert(Expression.Increment(Expression.Convert(par, Enum.GetUnderlyingType(typeof(TEnum)))), typeof(TEnum)) :
                    Expression.Increment(par);
                Increment = Expression.Lambda<Func<TEnum, TEnum>>(body, par).Compile();
            }
        }
    }

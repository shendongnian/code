    public static class OptionHelper
    {
        public static U GetOrElse<T, U>(this Option<T> o, U defAns)
            where T : U
        {
            if (o.IsSome) return o.GetUnsafe(); else return defAns;
        }
    }

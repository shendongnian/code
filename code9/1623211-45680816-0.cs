    public static class ObjectExtensions
    {
        public static Tout N<Tin, Tout>(this Tin val, Func<Tin, Tout> e)
        {
            if (val == null)
                return default(Tout);
            return e(val);
        }
    }

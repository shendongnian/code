    public static class Wrap<Tin, Tout>
    {
        public static Option<Tout, Exception> Chain(Tin input, Func<Tin, Tout> f)
        {
            try
            {
                return Option.Some<Tout,Exception>(f(input));
            }
            catch (Exception exc)
            {
                return Option.None<Tout, Exception>(exc);
            }
        }
        public static Option<Tout, Exception> TryChain(Option<Tin, Exception> input, Func<Tin, Tout> f)
        {
            return input.Match(
                    some: value => Chain(value, f),
                    none: exc => Option.None<Tout, Exception>(exc)
                );
        }
    }

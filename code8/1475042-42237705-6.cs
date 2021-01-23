    public static class Extensions {
        public static Option<Type2, Exception> TryChain(this Option<Type1, Exception> input, Func<Type1, Type2> f)
        {
            return Wrap<Type1, Type2>.TryChain(input, f);
        }
        public static Option<Type3, Exception> TryChain(this Option<Type2, Exception> input, Func<Type2, Type3> f)
        {
            return Wrap<Type2, Type3>.TryChain(input, f);
        }
        public static Option<Type4, Exception> TryChain(this Option<Type3, Exception> input, Func<Type3, Type4> f)
        {
            return Wrap<Type3, Type4>.TryChain(input, f);
        }
    }

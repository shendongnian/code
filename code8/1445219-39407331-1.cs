    public static class ActionExtensions
    {
        public static Func<bool> ToFunc(this Action action)
        {
            return () =>
            {
                action();
                return true;
            };
        }
    }

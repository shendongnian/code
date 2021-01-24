    public static class ToolsEx
    {
        public static IEnumerable<T> EnumerateAndDispose<X, T>(this X input, 
                                          Func<X, IEnumerable<T>> func)
            where X : IDisposable
        {
            using (var mc = input)
                foreach (var i in func(mc))
                    yield return i;
        }
    }

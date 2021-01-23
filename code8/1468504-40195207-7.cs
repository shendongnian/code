    public class SomeClass
    {
        static SomeClass()
        { 
            Cache = new AsyncLazy<Dictionary<string, TItem>>(GetCacheAsync);
        }
        public static AsyncLazy<Dictionary<string, TItem>> Cache { get; }
        private static Task<Dictionary<string, TItem>> GetCacheAsync()
        {
            ....
        }
    }. 

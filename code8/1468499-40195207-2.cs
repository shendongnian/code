    public class SomeClass
    {
        static SomeClass()
        { 
            Cache = new AsyncLazy<Dictionary<string, TItem>>(async () =>
            {
                var result = await FillCacheAsync();
                return result;
            });
        }
        protected static AsyncLazy<Dictionary<string, TItem>> Cache { get; }
    }. 

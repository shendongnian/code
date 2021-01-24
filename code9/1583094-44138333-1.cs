    public class SomeClass<T>
    {
        public SomeClass()
        {
            Foo = new AsyncLazy<List<T>>(async ()=> 
            {
                var data = await GetDataAsync();
                return data;
            });
        }
        public AsyncLazy<List<T>> Foo { get; } 
    }

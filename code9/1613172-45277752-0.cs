    public class SlowPart { }
    public class OtherPart { }
    public class SomePart: Lazy<Task<SlowPart>>
    {
        public SomePart(OtherPart eagerPart, Func<Task<SlowPart>> lazyPartFactory)
            : base(() => Task.Run(lazyPartFactory))
        {
            EagerPart = eagerPart;
        }
        public OtherPart EagerPart { get; }
        public TaskAwaiter<SlowPart> GetAwaiter() => Value.GetAwaiter();
    }

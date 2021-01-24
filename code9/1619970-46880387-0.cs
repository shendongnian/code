    public abstract class Foo: Controller
    {
        public Foo(ILogger<Foo> logger) {
            Logger = logger;
        }
        public ILogger Logger { get; private set; }
    }

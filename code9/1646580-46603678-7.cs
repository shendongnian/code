    public class HealthApiServiceBuilder
    {
        private readonly IFoo foo;
        private readonly IBar bar;
        public HealthApiServiceBuilder()
            // These are the default dependencies that can be overridden 
            // individually by the builder
            : this(new DefaultFoo(), new DefaultBar()) 
        { }
        internal HealthApiServiceBuilder(IFoo foo, IBar bar)
        {
            if (foo == null)
                throw new ArgumentNullException(nameof(foo));
            if (bar == null)
                throw new ArgumentNullException(nameof(bar));
            this.foo = foo;
            this.bar = bar;
        }
        public HealthApiServiceBuilder WithFoo(IFoo foo)
        {
            return new HealthApiServiceBuilder(foo, this.bar);
        }
        public HealthApiServiceBuilder WithBar(IBar bar)
        {
            return new HealthApiServiceBuilder(this.foo, bar);
        }
        public HealthApiService Build()
        {
            return new HealthApiService(this.foo, this.bar);
        }
    }

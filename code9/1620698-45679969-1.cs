    public class MyApplication : IMyApplication {
        public IProvider OneProvider { get; set; }
        public IProvider TwoProvider { get; set; }
    }
    public class RuleWithSettersRegistry : Registry {
        public RuleWithSettersRegistry() {
            For<IMyApplication>().Use<MyApplication>()            
                .Setter(x => x.OneProvider).Is(new FooProvider())
                .Setter(x => x.TwoProvider).Is(new BarProvider());            
        }
    }

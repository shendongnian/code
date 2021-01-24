    public class MyApplication : IApplication {
        public IProvider OneProvider { get; set; }
        public IProvider TwoProvider { get; set; }
    }
    public class RuleWithSettersRegistry : Registry {
        public RuleWithSettersRegistry() {
            //...other code removed for brevity
            For<IApplication>().Use<MyApplication>()
                // I would like to force FooProvider to bind-on OneProvider        
                .Setter(x => x.OneProvider).Is<FooProvider>()
                // I would like to force BarProvider to bind-on TwoProvider
                .Setter(x => x.TwoProvider).Is<BarProvider>();            
        }
    }

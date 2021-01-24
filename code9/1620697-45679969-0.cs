    public class MyApplication {
        [SetterProperty]
        public IFooProvider OneProvider { get; set; }
        [SetterProperty]
        public IBarProvider TwoProvider { get; set; }
    }
    public class FooProvider: IFooProvider { }
    public class BarProvider: IBarProvider { }

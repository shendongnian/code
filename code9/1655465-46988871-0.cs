    class A
    {
        [Inject]
        public B someProperty { get; set; }
    }
    
    class B
    {
        [Inject]
        public IResolve needResolve { get; set; }
    }

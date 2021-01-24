    class Bar {
        static Bar() {
            Resolver.Setup();
        }
    
        public voidFoo() {
            _DoTheJob();
        }
    
        [MethodImpl(MethodImplOptions.NoInlining)]
        void _DoTheJob() {
            var foo = new Foo();
            //...
        }
    }

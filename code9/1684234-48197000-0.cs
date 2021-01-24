        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(
                new NinjectSettings() { LoadExtensions = false },
                new DynamicProxyModule(),
                new FuncModule());
            AddInterceptors(kernel.Bind<ISomeClass>().To<SomeClass>());
            AddInterceptors(kernel.Bind<IOtherClass>().To<OtherClass>());
            AddInterceptors(kernel.Bind<IAnotherClass>().To<AnotherClass>());
            //kernel.Intercept(p => true).With(new ClassInterceptor());
            ISomeClass someClass = kernel.TryGet<ISomeClass>();
            someClass.Foo();
        }
        private static void AddInterceptors<T>(IBindingWhenInNamedWithOrOnSyntax<T> binding)
        {
            binding.Intercept(p => true).With(new ClassInterceptor());
            /* ... other interceptors ... */
        }

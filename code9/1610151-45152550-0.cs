        static void Main(string[] args)
        {
            using (var kernel = new StandardKernel())
            {
                kernel.Bind<A>().To<A>();
                kernel.Bind<B>().To<B>();
                kernel.Bind<C>().To<C>();
                for (var i = 0; i < 10; ++i)
                {
                    var c = kernel.Get<C>();
                    c.PrintHello();
                }
            }
        }

        static IContainer container;
        private static void InitializeAutoFac()
        {
            var builder = new ContainerBuilder();
            builder.Register<ProductFactory>(context =>
            {
                return (int id, DateTime dt, DateTime dt2) =>
                {
                    IProduct prod = new ConcreteProduct(id, dt, dt2);
                    return prod;
                };
            }).SingleInstance();
            builder.RegisterType<ProductOrder>().AsSelf();
            container = builder.Build();
        }

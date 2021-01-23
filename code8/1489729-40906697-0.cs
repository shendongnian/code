    public IContainer Configure(IAffiliate affiliate)
        {
            var builder = new ContainerBuilder();
            builder.Register(c => new ChannelRepository().Get(affiliate.Code)).As<IAffiliate>();
            builder.RegisterType<DbContext>().As<IDbContext>().InstancePerLifetimeScope();
           
            builder.RegisterType<OrderFactory>().As<IOrderFactory>();
            return builder.Build();
        }

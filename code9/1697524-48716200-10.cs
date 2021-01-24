    public class DependencyRegistration : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
            container.Register(Component.For<OrderValidator>());
            container.Register(
                Component.For<IOrderValidator,AddressValidator>()
                    .Named("AddressValidator"),
                Component.For<IOrderValidator,OrderLinesValidator>()
                    .Named("OrderLinesValidator"),
                Component.For<IOrderValidator,ProductStateRestrictionsValidator>()
                    .Named("ProductStateRestrictionsValidator")
                );
        }
    }

    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();
            container.Register(
                Component.For<IAddressValidator,UnitedStatesAddressValidator>()
                    .Named("AddressValidatorFor_USA"),
                Component.For<IAddressValidator, FinlandAddressValidator>()
                    .Named("AddressValidatorFor_FIN"),
                Component.For<IAddressValidator, MalawiAddressValidator>()
                    .Named("AddressValidatorFor_MWI"),
                Component.For<IAddressValidator, CommonCountryAddressValidator>()
                    .Named("FallbackCountryAddressValidator")
                    .IsDefault()            
                );
            container.Register(
                Component.For<IAddressValidatorFactory>()
                    .AsFactory(new AddressValidatorSelector())
                );
        }
    }

    public class Foo : IFoo
    {
        private readonly DbAuthorizationOptions authOptions;
        public Foo(DbAuthorizationOptions authOptions) // <-- Inject parameters
        {
            this.authOptions = authOptions ??
                throw new ArgumentNullException(nameof(authOptions));
        }
        public void DoSomething()
        {
            // TODO: Inject the type that has the BuildDynamicValidatorFactory
            // method and the serviceOption (whatever type that is) here
            // either as a method parameter of this method, or a constructor
            // parameter of this class.
            var validator = BuildDynamicValidatorFactory(serviceOption).Invoke(provider, null);
            // Now we have an instance of authOptions that can be used
            authOptions.ValidatorOptions.AddValidatorForSet(validator);
        }
    }

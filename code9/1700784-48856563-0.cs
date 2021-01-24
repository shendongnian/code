    public class Foo : IFoo
    {
        private readonly DbAuthorizationOptions authOptions;
        public Foo(DbAuthorizationOptions authOptions)
        {
            this.authOptions = authOptions ??
                throw new ArgumentNullException(nameof(authOptions));
        }
        public void DoSomething()
        {
            var validator = BuildDynamicValidatorFactory(serviceOption).Invoke(provider, null);
            // Now we have an instance of authOptions that can be used
            authOptions.ValidatorOptions.AddValidatorForSet(validator);
        }
    }

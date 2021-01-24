    public class MyManager : OpenIddictTokenManager<MyToken>
    {
        public MyManager(
            IOpenIddictTokenStore<MyToken> store,
            ILogger<OpenIddictTokenManager<MyToken>> logger)
            : base(store, logger)
        {
        }
    
        protected override Task PopulateAsync(MyToken token, OpenIddictTokenDescriptor descriptor, CancellationToken cancellationToken)
        {
            if (descriptor.Properties.TryGetValue("device_id", out var identifier))
            {
                token.DeviceId = identifier;
            }
    
            return base.PopulateAsync(token, descriptor, cancellationToken);
        }
    }

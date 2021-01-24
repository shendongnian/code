    public class CoreServiceSession : ICoreServiceSession
    {
        private static readonly ChannelFactory factory =
            new ChannelFactory<ISessionAwareCoreService>(myBinding, myEndpoint);
        public string CreateOrGetStubUris(string eclItemUri)
        {
            var client = factory.CreateChannel();
        
            try
            {
                return EclServiceClient.CreateOrGetStubUris(
                    new List<string> { eclItemUri }).FirstOrDefault();
            }
            finally
            {
                try
                {
                    ((IDisposable)client).Dispose();
                }
                catch
                {
                    // We need to swallow exceptions thrown by Dispose. 
                    // See: https://marcgravell.blogspot.com/2008/11/dontdontuse-using.html
                }
            }
        }
    }

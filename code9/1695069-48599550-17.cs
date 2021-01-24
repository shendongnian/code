    internal class ClientIpAuthorizationInterceptor : IInterceptor
    {
        private readonly IClientInfoProvider _clientInfoProvider;
        public ClientIpAuthorizationInterceptor(IClientInfoProvider clientInfoProvider)
        {
            _clientInfoProvider = clientInfoProvider;
        }
        public void Intercept(IInvocation invocation)
        {
            var methodInfo = invocation.MethodInvocationTarget;
            var clientIpAuthorizeAttribute = methodInfo.GetCustomAttributes(true).OfType<ClientIpAuthorizeAttribute>().FirstOrDefault()
                            ?? methodInfo.DeclaringType.GetCustomAttributes(true).OfType<ClientIpAuthorizeAttribute>().FirstOrDefault();
            if (clientIpAuthorizeAttribute != null &&
                clientIpAuthorizeAttribute.AllowedIpAddress != _clientInfoProvider.ClientIpAddress)
            {
                throw new AbpAuthorizationException();
            }
            invocation.Proceed();
        }
    }

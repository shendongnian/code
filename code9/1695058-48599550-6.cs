    internal static class ClientIpAuthorizationInterceptorRegistrar
    {
        public static void Initialize(IIocManager iocManager)
        {
            iocManager.IocContainer.Kernel.ComponentRegistered += (key, handler) =>
            {
                if (ShouldIntercept(handler.ComponentModel.Implementation))
                {
                    handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(ClientIpAuthorizationInterceptor)));
                }
            };
        }
        private static bool ShouldIntercept(Type type)
        {
            if (type.GetTypeInfo().IsDefined(typeof(ClientIpAuthorizeAttribute), true))
            {
                return true;
            }
            if (type.GetMethods().Any(m => m.IsDefined(typeof(ClientIpAuthorizeAttribute), true)))
            {
                return true;
            }
            return false;
        }
    }

     public static TRet CallWebServiceAndReturn<TInterface, TClient, TRet>(TClient client, string methodName, object[] parameters, bool cacheThis)
            where TInterface : class
            where TClient : ClientBase<TInterface>, TInterface
        {
           //......
        }

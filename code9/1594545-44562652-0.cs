    public static class NewAppDomain
    {
        public static void Execute(Action action)
        {
            AppDomain domain = null;
     
            try
            {
                domain = AppDomain.CreateDomain("New App Domain: " + Guid.NewGuid());
     
                var domainDelegate = (AppDomainDelegate)domain.CreateInstanceAndUnwrap(
                    typeof(AppDomainDelegate).Assembly.FullName,
                    typeof(AppDomainDelegate).FullName);
     
                domainDelegate.Execute(action);
            }
            finally
            {
                if (domain != null)
                    AppDomain.Unload(domain);
            }
        }
     
        private class AppDomainDelegate : MarshalByRefObject
        {
            public void Execute(Action action)
            {
                action();
            }
        }
    }

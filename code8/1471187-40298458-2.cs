    public object Execute(AppDomain domain, Func<object, object> toExecute, params object[] parameters)
        {
            var proxy = new Proxy(toExecute, parameters);
            var result = proxy.Invoke(domain);
            return result;
        }

        protected internal T UnProxyItem<T>(T proxyObject) where T : class
        {
            var proxyCreationEnabled = this.Configuration.ProxyCreationEnabled;
            try
            {
                this.Configuration.ProxyCreationEnabled = false;
                return this.Entry(proxyObject).CurrentValues.ToObject() as T;
            }
            finally
            {
                this.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
            }
        }

    public class WcfClientMyServiceFactory : IMyServiceFactory
    {
        public IMyService Create()
        {
            return new MyServiceClient();
        }
        public void Release(IMyService created)
        {
            var client = (MyServiceClient) created;
            try
            {
                try
                {
                    client.Close();
                }
                catch
                {
                    client.Abort();
                }
            }
            finally
            {
                client.Dispose();
            }
        }
    }

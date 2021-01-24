    namespace Application.Utilities
    {
        public class LocalMachine
        {
            // ... //
    
            public static bool isOnline()
            {
                try
                {
                    using (var client = new WebClient())
                    {
                        string serveraddress = AppSettings.GetServerHttpAddress();
                        using (var stream = client.OpenRead(serveraddress))
                        {
                            return true;
                        }
                    }
                }
                catch
                {
                    return false;
                }
            }
    
            // ... //
    }

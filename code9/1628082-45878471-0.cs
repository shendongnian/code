        public static class OutsideCode
        {
            public static void test()
            {
                var pi = new PluginCode(GetPluginMessager("this is a test session object"));
            }
    
            public static Func<string,int,string,bool> GetPluginMessager(object sessionInfo)
            {
                return delegate (string ip, int port, string message)
                {
                    Console.WriteLine($"session={sessionInfo.GetHashCode()}; ip={ip}; port={port}; message={message}");
                    return false;
                };
            }
        }
    
        public class PluginCode
        {
            public PluginCode(Func<string, int, string, bool> messager)
            {
                messager("127.0.0.1", 8080, "OK");
            }
        }

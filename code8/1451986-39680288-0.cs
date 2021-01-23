    using System.Net;
    
    namespace TestCase {
        public class Program
        {
            public static void Main ()
            {
                Dns.GetHostAddressesAsync ("smtp.gmail.com").GetAwaiter ().GetResult ();
            }
        }
    }

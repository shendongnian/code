    using System;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Text;
    namespace PingTest
    {
    public class PingExample
    {
        // args[0] can be an IPaddress or host name.
        public static void Main (string[] args)
        {
            Ping pingSender = new Ping ();
            PingOptions options = new PingOptions ();
            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;
            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes (data);
            int timeout = 120;
            PingReply reply = pingSender.Send (args[0], timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                
            }
        }
      }
    }

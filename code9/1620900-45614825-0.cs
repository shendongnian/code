    // example of multithreaded UdpClient with .NET core on Linux
    // works on Linux OpenSuSE LEAP 42.1 with .NET Command Line Tools (1.0.4)
    // passed tests with "time nping --udp -p 5555 --rate 2000000 -c 52000 -H localhost > /dev/null"
    
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    
    namespace hwapp {
      class Program {
        // listen to port 5555
        UdpClient udpListener = new UdpClient(5555);
    
        static void Main(string[] args) {
          Program p = new Program();
          // launch 5 threads
          Task t0 = p.listen("thread 0");
          Task t1 = p.listen("thread 1");
          Task t2 = p.listen("thread 2");
          Task t3 = p.listen("thread 3");
          Task t4 = p.listen("thread 4");
          t0.Wait(); t1.Wait(); t2.Wait(); t3.Wait(); t4.Wait();
        }
    
        public async Task listen(String s) {
          Console.WriteLine("running " + s);
          using (udpListener) {
            udpListener.Client.ReceiveBufferSize = 2000;
            int n = 0;
            while (n < 10000) {
              n = n + 1;
              try {
                UdpReceiveResult result = await udpListener.ReceiveAsync();
              } catch (Exception ex) {}
            }
          }
        }
      }
    }

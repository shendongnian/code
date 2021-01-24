    using System.Threading;
    using System.Threading.Tasks;
    using NetMQ;
    using NetMQ.Sockets;
    
    namespace SampleNQSub
    {
        class Program
        {
            static void Main(string[] args)
            {
                var addr = "tcp://127.0.0.1:3004";
    
                NetMQPoller poller = new NetMQPoller();
    
                using (var subSocket = new SubscriberSocket())
                {
                    subSocket.ReceiveReady += OnReceiveReady;
                    subSocket.Options.ReceiveHighWatermark = 10;
                    subSocket.Connect(addr);
                    subSocket.Subscribe("NQ");
    
                    poller.Add(subSocket);
                    poller.RunAsync();
    
                    for (int i = 0; i < 20; i++)
                    {
                        Thread.Sleep(1000);
                    }
    
                    subSocket.Disconnect(addr);
                }
            }
    
            static void OnReceiveReady(object sender, NetMQSocketEventArgs e)
            {
                var str = e.Socket.ReceiveFrameString();
                e.Socket.ReceiveMultipartStrings()
            }
        }
    }

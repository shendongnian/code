    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using XSockets.Core.XSocket.Helpers;
    
    
    class Program
    {
        static void Main(string[] args)
        {
            // Start server
            Task.Run(() =>
            {
                using (var server = XSockets.Plugin.Framework.Composable.GetExport<XSockets.Core.Common.Socket.IXSocketServerContainer>())
                {
                    server.Start();
                    Console.ReadLine();
                }
            });
    
            // Start client
            Task.Run(async () =>
            {
                //Just wait to make sure the server is up and running
                await Task.Delay(5000);
                var c = new XSockets.XSocketClient("ws://localhost:4502", "http://localhost");
                await c.Open();
    
                // Handle message when sent from server
                c.Controller("chat").On<Message>("message", (m) => Console.WriteLine($"Text:{m.Text}, Time:{m.Time}"));
    
                // Send 10 messages
                for (var i = 0; i < 10; i++)
                    await c.Controller("chat").Invoke("message", new Message { Text = "Hello World", Time = DateTime.Now });
            });
    
            Console.ReadLine();
        }
    }
    
    // Model/Message used in chat
    public class Message
    {
        public string Text { get; set; }
        public DateTime Time { get; set; }
    }
    // Controller
    public class Chat : XSockets.Core.XSocket.XSocketController
    {
        public async Task Message(Message m)
        {
            await this.InvokeToAll(m, "message");
        }
    }

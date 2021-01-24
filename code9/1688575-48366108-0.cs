    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    using DotNetty.Transport.Channels;
    using Newtonsoft.Json;
    using System.IO;
    
    namespace MultiClientSocketExample
    {
        public enum Command
        {
            Register = 1,  // Register a new client
            SendToClient = 2, // Send a message from one client to antoher
            DoClientAction = 3 // Replace this with your client-to-client command
        }
    
        // Envelope for all messages handled by the server
        public class Message
        {
            public string ClientId { get; set; }
            public Command Command { get; set; }
            public string Data { get; set; }
        }
    
        // Command for seding a message from one client to antoher.   
        // This would be serialized as JSON and stored in the 'Data' member of the Message object.
        public class SendToClientCommand
        {
            public string DestinationClientId { get; set; }  // The client to receive the message
    
            public Command ClientCommand { get; set; } // The command for the destination client to execute
    
            public string Data { get; set; } // The payload for the destination client
        }
    
        // An object for storing unhandled messages in a queue to be processed asynchronously
        // This allows us to process messages and respond to the appropriate client,
        // without having to do everything in the ChannelRead0 method and block the main thread
        public class UnhandledMessage
        {
            private readonly Message message;
            private readonly IChannelHandlerContext context;
    
            public UnhandledMessage(Message message, IChannelHandlerContext context)
            {
                this.message = message;
                this.context = context;
            }
    
            public Message Message => message;
            public IChannelHandlerContext Context => context;
    
            public Command Command => message.Command;
            public string ClientId => message.ClientId;
            public string Data => message.Data;
        }
    
        // A representation of the connected Clients on the server.  
        // Note:  This is not the 'Client' class that would be used to communicate with the server.
        public class Client
        {
            private readonly string clientId;
            private readonly IChannelHandlerContext context;
    
            public Client(string clientId, IChannelHandlerContext context)
            {
                this.clientId = clientId;
                this.context = context;
            }
    
            public string ClientId => clientId;
            public IChannelHandlerContext Context => context;
        }
    
        // The socket server, using DotNetty's SimpleChannelInboundHandler
        // The ChannelRead0 method is called for each Message received
        public class Server : SimpleChannelInboundHandler<Message>, IDisposable
        {
            private readonly ConcurrentDictionary<string, Client> clients;
            private readonly ConcurrentQueue<UnhandledMessage> unhandledMessages;
            private readonly CancellationTokenSource cancellation;
            private readonly AutoResetEvent newMessage;
    
            public Server(CancellationToken cancellation)
            {
                this.clients = new ConcurrentDictionary<string, Client>();
                this.newMessage = new AutoResetEvent(false);
                this.cancellation = CancellationTokenSource.CreateLinkedTokenSource(cancellation);
            }
    
            // The start method should be called when the server is bound to a port.
            // Messages will be received, but will not be processed unless/until the Start method is called
            public Task Start()
            {
                // Start a dedicated thread to process messages so that the ChannelRead operation does not block
                return Task.Run(() =>
                {
                    var serializer = JsonSerializer.CreateDefault();  // This will be used to deserialize the Data member of the messages
    
                    while (!cancellation.IsCancellationRequested)
                    {
                        UnhandledMessage message;
                        var messageEnqueued = newMessage.WaitOne(100);  // Sleep until a new message arrives
    
                        while (unhandledMessages.TryDequeue(out message))  // Process each message in the queue, then sleep until new messages arrive
                        {
                            if (message != null)
                            {
                                // Note: This part could be sent to the thread pool if you want to process messages in parallel
                                switch (message.Command)
                                {
                                    case Command.Register:
                                        // Register a new client, or update an existing client with a new Context
                                        var client = new Client(message.ClientId, message.Context);
                                        clients.AddOrUpdate(message.ClientId, client, (_,__) => client);
                                        break;
                                    case Command.SendToClient:
                                        Client destinationClient;
                                        using (var reader = new JsonTextReader(new StringReader(message.Data)))
                                        {
                                            var sendToClientCommand = serializer.Deserialize<SendToClientCommand>(reader);
                                            if (clients.TryGetValue(sendToClientCommand.DestinationClientId, out destinationClient))
                                            {
                                                var clientMessage = new Message { ClientId = message.ClientId, Command = sendToClientCommand.ClientCommand, Data = sendToClientCommand.Data };
                                                destinationClient.Context.Channel.WriteAndFlushAsync(clientMessage);
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }, cancellation.Token);
            }
    
            // Receive each message from the clients and enqueue them to be procesed by the dedicated thread
            protected override void ChannelRead0(IChannelHandlerContext context, Message message)
            {
                unhandledMessages.Enqueue(new UnhandledMessage(message, context));
                newMessage.Set(); // Trigger an event so that the thread processing messages wakes up when a new message arrives
            }
    
            // Flush the channel once the Read operation has completed
            public override void ChannelReadComplete(IChannelHandlerContext context)
            {
                context.Flush();
                base.ChannelReadComplete(context);
            }
    
            // Automatically stop the message-processing thread when this object is disposed
            public void Dispose()
            {
                cancellation.Cancel();
            }
        }
    }

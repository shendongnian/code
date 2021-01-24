    using System;
    using System.Net.Sockets;
    using System.Threading;
    using System.Threading.Tasks;
    using Grpc.Core;
    using Helloworld;
    
    namespace GreeterServer
    {
      class GreeterImpl : Greeter.GreeterBase
      {
        // Server side handler of the SayHello RPC
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
          Program.Shutdown.Set(); // <--- Signals the main thread to continue 
          return Task.FromResult(new HelloReply {Message = "Hello " + request.Name});
        }
      }
    
      class Program
      {
        const int Port = 50051;
    
        public static ManualResetEvent Shutdown = new ManualResetEvent(false);
    
        public static void Main(string[] args)
        {
          Server server = new Server
          {
            Services = {Greeter.BindService(new GreeterImpl())},
            Ports = {new ServerPort("localhost", Port, ServerCredentials.Insecure)}
          };
          server.Start();
              
          Shutdown.WaitOne(); // <--- Waits for ever or signal received
    
          server.ShutdownAsync().Wait();
        }
      }
    }

    using System.Threading;
    using System.Threading.Tasks;
    using Grpc.Core;
    using Microsoft.Extensions.Hosting;
    
    namespace Grpc.Host
    {
        public class GrpcHostedService: IHostedService
        {
            private Server _server;
    
            public GrpcHostedService(Server server)
            {
                _server = server;
            }
    
            public Task StartAsync(CancellationToken cancellationToken)
            {
                _server.Start();
                return Task.CompletedTask;
            }
    
            public async Task StopAsync(CancellationToken cancellationToken) => await _server.ShutdownAsync();
        }
    }

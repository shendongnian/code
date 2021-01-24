    namespace PipesAsyncAwait471
    {
        using System;
        using System.Collections.Generic;
        using System.Diagnostics.CodeAnalysis;
        using System.IO;
        using System.IO.Pipes;
        using System.Linq;
        using System.Threading.Tasks;
        internal class Program
        {
            private const int MAX_CLIENTS = 1000;
            private const int MAX_REQUESTS = 100;
            private static async Task Main()
            {
                List<Task> tasks = new List<Task> {
                    HandleRequestAsync(0)
                };
                tasks.AddRange(Enumerable.Range(0, MAX_CLIENTS).Select(i => SendRequestAsync(i, 0, MAX_REQUESTS)));
                await Task.WhenAll(tasks);
            }
            [SuppressMessage("ReSharper", "FunctionRecursiveOnAllPaths")]
            private static async Task HandleRequestAsync(int counter)
            {
                NamedPipeServerStream server = null;
                int clientId = -1;
                int requestId = -1;
                try {
                    server = new NamedPipeServerStream("MyPipe",
                                                    PipeDirection.InOut,
                                                    NamedPipeServerStream.MaxAllowedServerInstances,
                                                    PipeTransmissionMode.Message,
                                                    PipeOptions.None);
                    Console.WriteLine($"Waiting a client... ({counter})");
                    await server.WaitForConnectionAsync().ConfigureAwait(false);
                    if (server.IsConnected) {
                        if (server.CanRead) {
                            var request = new byte[8];
                            await server.ReadAsync(request, 0, request.Length).ConfigureAwait(false);
                            clientId = BitConverter.ToInt32(request, 0);
                            requestId = BitConverter.ToInt32(request, 4);
                            Console.WriteLine($"{clientId}:{requestId}:3 Client ping reached the server.");
                        }
                        if (clientId > -1 && server.CanWrite) {
                            var response = new[] { clientId, requestId }.SelectMany(BitConverter.GetBytes).ToArray();
                            await server.WriteAsync(response, 0, response.Length).ConfigureAwait(false);
                            await server.FlushAsync().ConfigureAwait(false);
                            server.WaitForPipeDrain();
                            Console.WriteLine($"{clientId}:{requestId}:4 Server pong client.");
                        }
                    }
                }
                catch (IOException ex) {
                    Console.WriteLine(ex);
                }
                finally {
                    if (server != null) {
                        server.Disconnect();
                        server.Dispose();
                    }
                    Console.WriteLine($"{clientId}:{requestId}:5 Server disconnected from client.");
                    
                    await HandleRequestAsync(++counter).ConfigureAwait(false);
                }
            }
            private static async Task SendRequestAsync(int clientId, int requestId, byte max)
            {
                NamedPipeClientStream client = null;
                try {
                    client = new NamedPipeClientStream(".", "MyPipe", PipeDirection.InOut, PipeOptions.None);
                    await client.ConnectAsync().ConfigureAwait(false);
                    if (client.IsConnected) {
                        Console.WriteLine($"{clientId}:{requestId}:1 Client connected.");
                        if (client.CanWrite) {
                            var request = new[] { clientId, requestId }.SelectMany(BitConverter.GetBytes).ToArray();
                            await client.WriteAsync(request, 0, request.Length).ConfigureAwait(false);
                            await client.FlushAsync().ConfigureAwait(false);
                            client.WaitForPipeDrain();
                            Console.WriteLine($"{clientId}:{requestId}:2 Client ping the server.");
                        }
                        if (client.CanRead) {
                            var response = new byte[8];
                            await client.ReadAsync(response, 0, response.Length).ConfigureAwait(false);
                            Console.WriteLine($"{BitConverter.ToInt32(response, 0)}:{BitConverter.ToInt32(response, 4)}:6 Server pong reached client.");
                        }
                        if (requestId <= max) {
                            await SendRequestAsync(clientId, ++requestId, max).ConfigureAwait(false);
                        }
                        else {
                            Console.WriteLine($"{clientId}:{++max}:7 Client done!");
                        }
                    }
                }
                catch (FileNotFoundException) {
                    // todo: Implement some sort of flow control
                    Console.WriteLine($"{clientId}:{requestId}:8! Client ping the server.");
                    await SendRequestAsync(clientId, requestId, max).ConfigureAwait(false);
                }
                finally {
                    client?.Dispose();
                }
            }
        }
    }

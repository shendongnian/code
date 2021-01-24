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
            private static async Task Main()
            {
                List<Task> tasks = new List<Task> {
                    HandleRequestAsync()
                };
                tasks.AddRange(Enumerable.Range(0, 10).Select(i => SendRequestAsync(i, 0, 5)));
                await Task.WhenAll(tasks);
            }
            [SuppressMessage("ReSharper", "FunctionRecursiveOnAllPaths")]
            private static async Task HandleRequestAsync()
            {
                NamedPipeServerStream server = null;
                int index = -1;
                int id = -1;
                try {
                    server = new NamedPipeServerStream("MyPipe",
                                                    PipeDirection.InOut,
                                                    NamedPipeServerStream.MaxAllowedServerInstances,
                                                    PipeTransmissionMode.Message,
                                                    PipeOptions.Asynchronous);
                    Console.WriteLine("Waiting a client...");
                    await server.WaitForConnectionAsync().ConfigureAwait(false);
                    if (server.IsConnected) {
                        if (server.CanRead) {
                            var request = new byte[2];
                            await server.ReadAsync(request, 0, request.Length).ConfigureAwait(false);
                            index = request[0];
                            id = request[1];
                            Console.WriteLine($"{index}:{id}:3 Client ping reached the server.");
                        }
                        if (index > -1 && server.CanWrite) {
                            var response = new[] { (byte)index, (byte)id };
                            await server.WriteAsync(response, 0, response.Length).ConfigureAwait(false);
                            Console.WriteLine($"{index}:{id}:4 Server pong client.");
                            await server.FlushAsync().ConfigureAwait(false);
                            server.WaitForPipeDrain();
                        }
                    }
                }
                catch (IOException ex) {
                    Console.WriteLine(ex);
                }
                finally {
                    server?.Disconnect();
                    Console.WriteLine($"{index}:{id}:5 Server disconnected from client.");
                    server?.Dispose();
                    await HandleRequestAsync().ConfigureAwait(false);
                }
            }
            private static async Task SendRequestAsync(int index, int id, int max)
            {
                NamedPipeClientStream client = null;
                try {
                    client = new NamedPipeClientStream(".", "MyPipe", PipeDirection.InOut, PipeOptions.Asynchronous);
                    await client.ConnectAsync().ConfigureAwait(false);
                    if (client.IsConnected) {
                        Console.WriteLine($"{index}:{id}:1 Client connected.");
                        if (client.CanWrite) {
                            var request = new[] { (byte)index, (byte)id };
                            await client.WriteAsync(request, 0, request.Length).ConfigureAwait(false);
                            Console.WriteLine($"{index}:{id}:2 Client ping the server.");
                            await client.FlushAsync().ConfigureAwait(false);
                            client.WaitForPipeDrain();
                        }
                        if (client.CanRead) {
                            var response = new byte[2];
                            await client.ReadAsync(response, 0, response.Length).ConfigureAwait(false);
                            Console.WriteLine($"{response[0]}:{response[1]}:6 Server pong reached client.");
                        }
                        if (id <= max) {
                            await SendRequestAsync(index, ++id, max).ConfigureAwait(false);
                        }
                        else {
                            Console.WriteLine($"{index}:{++max}:7 Client done!");
                        }
                    }
                }
                catch (IOException ex) {
                    Console.WriteLine(ex);
                }
                finally {
                    client?.Dispose();
                }
            }
        }
    }

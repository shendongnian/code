    namespace PipesAsyncAwait471
    {
        using System;
        using System.Collections.Generic;
        using System.Diagnostics.CodeAnalysis;
        using System.IO;
        using System.IO.Pipes;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        internal class Program
        {
            private const string LOG_FILE = @"D:\PipesAsyncAwait471.log";
            private const int MAX_CLIENTS = 10;
            private const int MAX_REQUESTS = 10;
            private static readonly FileStream _fs = new FileStream(LOG_FILE, FileMode.Create, FileAccess.Write, FileShare.ReadWrite, 4096, FileOptions.None | FileOptions.WriteThrough);
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
                StreamWriter logger = new StreamWriter(_fs, Encoding.ASCII, 4096, true);
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
                            await logger.WriteAsync($"{clientId}:{requestId}:3 Client ping reached the server.\r\n").ConfigureAwait(false);
                            await logger.FlushAsync().ConfigureAwait(false);
                        }
                        if (clientId > -1 && server.CanWrite) {
                            var response = new[] { clientId, requestId }.SelectMany(BitConverter.GetBytes).ToArray();
                            await server.WriteAsync(response, 0, response.Length).ConfigureAwait(false);
                            await server.FlushAsync().ConfigureAwait(false);
                            server.WaitForPipeDrain();
                            await logger.WriteAsync($"{clientId}:{requestId}:4 Server pong client.\r\n").ConfigureAwait(false);
                            await logger.FlushAsync().ConfigureAwait(false);
                        }
                    }
                }
                catch (IOException ex) {
                    await logger.WriteAsync(ex.ToString()).ConfigureAwait(false);
                }
                finally {
                    if (server != null) {
                        server.Disconnect();
                        server.Dispose();
                        await logger.WriteAsync($"{clientId}:{requestId}:5 Server disconnected from client.\r\n").ConfigureAwait(false);
                        await logger.FlushAsync().ConfigureAwait(false);
                    }
                    logger.Dispose();
                    await HandleRequestAsync(++counter).ConfigureAwait(false);
                }
            }
            private static async Task SendRequestAsync(int clientId, int requestId, byte max)
            {
                NamedPipeClientStream client = null;
                StreamWriter logger = new StreamWriter(_fs, Encoding.ASCII, 4096, true);
                try {
                    client = new NamedPipeClientStream(".", "MyPipe", PipeDirection.InOut, PipeOptions.None);
                    await client.ConnectAsync().ConfigureAwait(false);
                    if (client.IsConnected) {
                        await logger.WriteAsync($"{clientId}:{requestId}:1 Client connected.\r\n").ConfigureAwait(false);
                        await logger.FlushAsync().ConfigureAwait(false);
                        if (client.CanWrite) {
                            var request = new[] { clientId, requestId }.SelectMany(BitConverter.GetBytes).ToArray();
                            await client.WriteAsync(request, 0, request.Length).ConfigureAwait(false);
                            await client.FlushAsync().ConfigureAwait(false);
                            client.WaitForPipeDrain();
                            await logger.WriteAsync($"{clientId}:{requestId}:2 Client ping the server.\r\n").ConfigureAwait(false);
                            await logger.FlushAsync().ConfigureAwait(false);
                        }
                        if (client.CanRead) {
                            var response = new byte[8];
                            await client.ReadAsync(response, 0, response.Length).ConfigureAwait(false);
                            await logger.WriteAsync($"{BitConverter.ToInt32(response, 0)}:{BitConverter.ToInt32(response, 4)}:6 Server pong reached client.\r\n").ConfigureAwait(false);
                            await logger.FlushAsync().ConfigureAwait(false);
                        }
                        if (requestId <= max) {
                            await SendRequestAsync(clientId, ++requestId, max).ConfigureAwait(false);
                        }
                        else {
                            await logger.WriteAsync($"{clientId}:{++max}:7 Client done!\r\n").ConfigureAwait(false);
                            await logger.FlushAsync().ConfigureAwait(false);
                        }
                    }
                }
                catch (FileNotFoundException) {
                    // todo: Implement some sort of flow control
                    await logger.WriteAsync($"{clientId}:{requestId}:8 Client ping the server.\r\n").ConfigureAwait(false);
                    await logger.FlushAsync().ConfigureAwait(false);
                    await SendRequestAsync(clientId, requestId, max).ConfigureAwait(false);
                }
                catch (IOException ex) {
                    await logger.WriteAsync(ex.ToString()).ConfigureAwait(false);
                    await logger.FlushAsync().ConfigureAwait(false);
                }
                finally {
                    client?.Dispose();
                    logger.Dispose();
                }
            }
        }
    }

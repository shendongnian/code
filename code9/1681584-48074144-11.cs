    namespace PipesAsyncAwait471
    {
        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.IO.Pipes;
        using System.Linq;
        using System.Threading.Tasks;
        internal class Program
        {
            private const int MAX_REQUESTS = 1000;
            private static void Main()
            {
                var tasks = new List<Task> {
                    //Task.Run(() => HandleRequest(0))
                    HandleRequestAsync(0)
                };
                tasks.AddRange(Enumerable.Range(0, MAX_REQUESTS).Select(i => Task.Factory.StartNew(() => SendRequest(i), TaskCreationOptions.LongRunning)));
                Task.WhenAll(tasks);
                Console.ReadKey();
            }
            private static void HandleRequest(int counter)
            {
                try {
                    var server = new NamedPipeServerStream("MyPipe",
                                                        PipeDirection.InOut,
                                                        NamedPipeServerStream.MaxAllowedServerInstances,
                                                        PipeTransmissionMode.Message,
                                                        PipeOptions.Asynchronous);
                    Console.WriteLine($"Waiting a client... {counter}");
                    server.BeginWaitForConnection(WaitForConnectionCallback, server);
                }
                catch (Exception ex) {
                    Console.WriteLine(ex);
                }
                void WaitForConnectionCallback(IAsyncResult result)
                {
                    var server = (NamedPipeServerStream)result.AsyncState;
                    try {
                        server.EndWaitForConnection(result);
                        HandleRequest(++counter);
                        if (server.IsConnected) {
                            var request = new byte[4];
                            server.BeginRead(request, 0, request.Length, ReadCallback, server);
                            int index = BitConverter.ToInt32(request, 0);
                            Console.WriteLine($"{index} Request.");
                            var response = BitConverter.GetBytes(index);
                            server.BeginWrite(response, 0, response.Length, WriteCallback, server);
                            server.Flush();
                            server.WaitForPipeDrain();
                            Console.WriteLine($"{index} Pong.");
                            server.Disconnect();
                            Console.WriteLine($"{index} Disconnected.");
                        }
                    }
                    catch (IOException) {
                        HandleRequest(++counter);
                    }
                    finally {
                        server.Dispose();
                    }
                }
                void ReadCallback(IAsyncResult result) 
                {
                    var server = (NamedPipeServerStream)result.AsyncState;
                    try {
                        server.EndRead(result);
                    }
                    catch (IOException ex) {
                        Console.WriteLine(ex);
                    }
                }
                void WriteCallback(IAsyncResult result) 
                {
                    var server = (NamedPipeServerStream)result.AsyncState;
                    try {
                        server.EndWrite(result);
                    }
                    catch (IOException ex) {
                        Console.WriteLine(ex);
                    }
                }
            }
            private static async Task HandleRequestAsync(int counter)
            {
                NamedPipeServerStream server = null;
                try {
                    server = new NamedPipeServerStream("MyPipe",
                                                    PipeDirection.InOut,
                                                    NamedPipeServerStream.MaxAllowedServerInstances,
                                                    PipeTransmissionMode.Message,
                                                    PipeOptions.Asynchronous);
                    Console.WriteLine($"Waiting a client... {counter}");
                    await server.WaitForConnectionAsync()
                                .ContinueWith(async t => await HandleRequestAsync(++counter).ConfigureAwait(false))
                                .ConfigureAwait(false);
                    if (server.IsConnected) {
                        var request = new byte[4];
                        await server.ReadAsync(request, 0, request.Length).ConfigureAwait(false);
                        int index = BitConverter.ToInt32(request, 0);
                        Console.WriteLine($"{index} Request.");
                        var response = BitConverter.GetBytes(index);
                        await server.WriteAsync(response, 0, response.Length).ConfigureAwait(false);
                        await server.FlushAsync().ConfigureAwait(false);
                        server.WaitForPipeDrain();
                        Console.WriteLine($"{index} Pong.");
                        server.Disconnect();
                        Console.WriteLine($"{index} Disconnected.");
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine(ex);
                }
                finally {
                    server?.Dispose();
                }
            }
            private static void SendRequest(int index)
            {
                NamedPipeClientStream client = null;
                try {
                    client = new NamedPipeClientStream(".", "MyPipe", PipeDirection.InOut, PipeOptions.None);
                    client.Connect();
                    var request = BitConverter.GetBytes(index);
                    client.Write(request, 0, request.Length);
                    client.Flush();
                    client.WaitForPipeDrain();
                    Console.WriteLine($"{index} Ping.");
                    var response = new byte[4];
                    client.Read(response, 0, response.Length);
                    index = BitConverter.ToInt32(response, 0);
                    Console.WriteLine($"{index} Response.");
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

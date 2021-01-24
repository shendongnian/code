    public async Task<string> GetAllAsync(string url, string bodyMessage,
                Dictionary<string, string> additionalHeaders)
            {
                _securityService.SetClientToken().Wait();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls |
                                                       SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
    
                var cancellationTokenSource = new CancellationTokenSource(new TimeSpan(1, 1, 0, 0));
                using (ClientWebSocket clientWebSocket = new ClientWebSocket())
                {
                    Uri serverUri = new Uri(url);
                    clientWebSocket.Options.SetRequestHeader("Authorization", $"Bearer {Endpoint.ClientAccessToken}");
                    foreach (var additionalHeader in additionalHeaders)
                    {
                        clientWebSocket.Options.SetRequestHeader(additionalHeader.Key, additionalHeader.Value);
                    }
                    try
                    {
                        clientWebSocket.ConnectAsync(serverUri, cancellationTokenSource.Token)
                            .Wait(cancellationTokenSource.Token);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                        throw;
                    }
                    while (clientWebSocket.State == WebSocketState.Open)
                    {
                        ArraySegment<byte> bytesToSend = new ArraySegment<byte>(Encoding.UTF8.GetBytes(bodyMessage));
                        await clientWebSocket.SendAsync(bytesToSend, WebSocketMessageType.Text, true,
                            CancellationToken.None);
                        ArraySegment<byte> bytesReceived = new ArraySegment<byte>(new byte[1024]);
                        WebSocketReceiveResult result =
                            await clientWebSocket.ReceiveAsync(bytesReceived, CancellationToken.None);
                        var response = Encoding.UTF8.GetString(bytesReceived.Array, 0, result.Count);
                        return response;
                    }
                }
                return null;
            }

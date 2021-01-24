     IDisposable subscription = null;
     ...
     subscription = source
                    // close websocket eventually
                    .Finally(() => webSocket.CloseAsync(WebSocketCloseStatus.Empty, String.Empty, CancellationToken.None).Wait())
                    .Subscribe(
                        data =>
                        {
                            if (webSocket.State != WebSocketState.Open)
                            {
                                _logger.LogWarning("Websocket closed by client!");
                                subscription.Dispose(); // End subscription
                            }
                            try
                            {
                                webSocket.SendAsync(data.ToString(),
                                    WebSocketMessageType.Text, true, CancellationToken.None).Wait();
                            }
                            catch (WebSocketException e)
                            {
                                _logger.LogWarning(e, "problem with websocket!");
                                subscription.Dispose(); // End subscription
                            }
                        });

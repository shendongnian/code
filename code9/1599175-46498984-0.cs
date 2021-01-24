    WebSocketReceiveResult result = null;
    while(running) {
        do {
            result = await socket.ReceiveAsync(buffer, cts.Token).ConfigureAwait(false);
            if (result.Count > 0)
            {
                 memStream.Write(buffer.Array, buffer.Offset, result.Count);
            }
            else
            {
                 logger.LogWarning("WS recved zero: {0}, {1}", result.Count, socket.State);
                 break;
            }
        } while (!result.EndOfMessage); // check end of message mark
    }

    var sendTask = SendAsync(cancellationToken, webSocket);
    var receiveTask = ReceiveAsync(cancellationToken, webSocket);
    while (!cancellationToken.IsCancellationRequested)
    {
        if (await Task.WhenAny(sendTask, receiveTask) == sendTask)
        {
            // The server has finished sending to the client or it had nothing to send.
            await sendTask;
            sendTask = SendAsync(cancellationToken, webSocket);
            continue;
        }
        var message = await receiveTask;
        // TODO: Process message here
        receiveTask = ReceiveAsync(cancellationToken, webSocket);
    }
    await webSocket.CloseAsync(
        WebSocketCloseStatus.NormalClosure,
        string.Empty,
        cancellationToken);

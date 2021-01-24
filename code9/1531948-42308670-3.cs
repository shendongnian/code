    while(_there_are_messages_in_queue)
    {
        // Simplified. Should be taken from the message queue.
        var data = "message";
        await webSocket.SendAsync(
            new System.ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes(data)),
            WebSocketMessageType.Text,
            true,
            cancellationToken);
    }
    await Task.Delay(1000);

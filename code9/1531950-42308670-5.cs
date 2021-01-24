    while(_there_is_a_messages_in_queue_)
    {     
        var data = "message"; // Simplified. Should be taken from the message queue.
        await webSocket.SendAsync(
            new System.ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes(data)),
            WebSocketMessageType.Text,
            true,
            cancellationToken);
    }
    await Task.Delay(1000);

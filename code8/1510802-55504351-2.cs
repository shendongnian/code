private static async Task SendAnswer(Message msg, WebSocket socket)
{
    var answer = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(msg).ToCharArray());
    var bufferSize = 8000;
    var endOfMessage = false;
    for (var offset = 0; offset < answer.Length; offset += bufferSize)
    {
        if (offset + bufferSize >= answer.Length)
        {
            bufferSize = answer.Length - offset;
            endOfMessage = true;
        }
        await socket.SendAsync(new ArraySegment<byte>(answer, offset, bufferSize),
            WebSocketMessageType.Text, endOfMessage, CancellationToken.None);
    }
}
And when receiving, you can also split the reception in chunks, so you can control you buffer (and therefore you memory consumption). After hanlding the whole message, you should wait for another message from the client to do more stuff. [Source](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/websockets?view=aspnetcore-2.2)
private async Task ReceiveMessage(WebSocket webSocket)
{
    var buffer = new byte[8000];
    var result = await webSocket.ReceiveAsync(buffer, CancellationToken.None);
    while (!result.CloseStatus.HasValue)
    {
        string msg = Encoding.UTF8.GetString(new ArraySegment<byte>(buffer, 0, result.Count).ToArray());
        while (!result.EndOfMessage)
        {
            result = await webSocket.ReceiveAsync(buffer, CancellationToken.None);
            msg += Encoding.UTF8.GetString(new ArraySegment<byte>(buffer, 0, result.Count).ToArray());
        }
        //At this point, `msg` has the whole message you sent, you can do whatever you want with it.
        // [...]
        //After you handle the message, wait for another message from the client
        result = await webSocket.ReceiveAsync(buffer, CancellationToken.None);
    }
    await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
}

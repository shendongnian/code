    private async Task<bool> DoSend()
    {
        bool success = true;
        try
        {
            await _ws.SendAsync(new ArraySegment<byte>(arrbr), WebSocketMessageType.Text, true, ctk);
        }
        catch (Exception ex)
        {
            // Do some logging with ex
            success = false;
        }
        return success;
    }

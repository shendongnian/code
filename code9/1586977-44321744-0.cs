    public void ChatMessage(string message)
    {
        this.InvokeToAll(message, "chatmessage");
    }
    

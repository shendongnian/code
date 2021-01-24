    public class Message
    {
        public string Text { get; set; }
        public DateTime Time { get; set; }
    }
    public class Chat : XSockets.Core.XSocket.XSocketController
    {
        public async Task Message(Message m)
        {
            await this.InvokeToAll(m, "message");
        }
    }
    

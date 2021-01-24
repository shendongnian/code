    public class Chat : XSockets.Core.XSocket.XSocketController
    {
        public async Task Message(string m)
        {
            // Broadcast... not very good... but it is just an example.
            await this.InvokeToAll(m, "message");
        }
    }

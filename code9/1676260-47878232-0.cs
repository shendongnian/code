    static void Main(string[] args)
        => new Program().RunBotAsync().GetAwaiter().GetResult();
    public async Task RunBotAsync() {
        _client.MessageReceived += MessageReceived;
    }
    private async Task MessageReceived(SocketMessage msg) {
        //Code to direct message here
    }

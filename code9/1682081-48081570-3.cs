    static async Task MainAsync() {
        try {
            var hubConnection = new HubConnection("http://localhost:12923/");
            IHubProxy stockTickerHubProxy = hubConnection.CreateHubProxy("MyHubServer");
            stockTickerHubProxy.On<string>("Associate", data => Console.WriteLine("Notification received : ", data));
            await hubConnection.Start();
            await stockTickerHubProxy.Invoke("JoinGroup", "123456", "Associate");
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
        }
    }

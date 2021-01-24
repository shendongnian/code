    public class MyClientAdapter : IMyAppService
    {
        private readonly Lazy<Task<MyClient>> connectedClient;
        public MyClientAdapter()
        {
            this.connectedClient = new Lazy<Task<MyClient>>(async () =>
            {
                var client = new MyClient();
                await client.ConnectAsync();
                return client;
            });
        }
        public async Task<Data> GetData()
        {
            var client = await this.connectedClient.Value;
            return await client.GetData();
        }
        public async Task SendData(Data data)
        {
            var client = await this.connectedClient.Value;
            await client.SendData(data);
        }
    }

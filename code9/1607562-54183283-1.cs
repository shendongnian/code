public class EventHubService : IEventHubService
{
    private EventHubClient Client { get; set; }
    public void Connect(string connectionString, string entityPath)
    {
        var connectionStringBuilder = new EventHubsConnectionStringBuilder(connectionString)
            {
                EntityPath = entityPath
            };
        Client =  EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
    }
    public async void Disconnect()
    {
        await Client.CloseAsync();
    }
    public Task SendAsync(EventData eventData)
    {
        return Client.SendAsync(eventData);
    }
}
And then testing is easy: `var eventHubService = new Mock<IEventHubService>();`

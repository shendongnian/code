    [HubName("YourHubName")]
    public class YourHubName : Hub
    {
        [HubMethodName("Subscribe")]
        public void Subscribe(string groupId)
        {                       
            Groups.Add(Context.ConnectionId, groupId);
            Clients.Group(groupId).addMessageToPage("Sucessfully subscribed to group : " + groupId);
        }
    }

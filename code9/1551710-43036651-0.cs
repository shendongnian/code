    [RoutePrefix("api/messaging")]
    public class MessagingController : ApiController
    {
        [Route("")]
        public void Post(Message message)
        {
            var notificationHub = GlobalHost.ConnectionManager.GetHubContext<MessageHub>();
            if (notificationHub != null)
            {
                try
                { 
                   // create your record   
                   notificationHub.Clients.All.creationSuccess(message);
                }
                catch (Exception ex)
                {
                  // do a thing
                }
            }
        }
    }

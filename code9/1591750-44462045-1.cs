    public abstract class ApiControllerWithHubController<THub> : ApiController where THub : IHub {
        private readonly IHubContext hub;
        public ApiControllerWithHubController(IHubContextProvider context) {
            this.hub = context.Hub;
        }
        protected IHubContext Hub {
            get { return hub; }
        }
    }
    public class NotificationController : ApiControllerWithHubController<HubServer> {
        public NotificationController(IHubContextProvider context)
            : base(context) {
        }
        [HttpPost]
        public IHttpActionResult SendNotification(NotificationInput notification) {
            Hub.Clients.Group("GroupName").BroadcastCustomerGreeting("notification");
            return Ok();
        }
    }

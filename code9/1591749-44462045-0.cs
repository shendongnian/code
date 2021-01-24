    public interface IHubContextProvider {
        IHubContext Hub { get; }
    }
    public class HubContextProvider<THub> : IHubContextProvider where THub : IHub {
        Lazy<IHubContext> hub = new Lazy<IHubContext>(() => GlobalHost.ConnectionManager.GetHubContext<THub>());
        public IHubContext Hub {
            get { return hub.Value; }
        }
    }

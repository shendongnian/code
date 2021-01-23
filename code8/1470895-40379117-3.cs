	public class ServiceFactory {
		public ServiceFactory(Func<IWcfEndpoint, IService> resolveService){
			_resolveService = resolveService;
		}
		public IService GetService(string hostName){
			return _resolveService(WcfEndpoint.BoundTo(new NetTcpBinding()).At($"net.tcp://{hostName}:port"));
		}
	}

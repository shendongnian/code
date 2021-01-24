	public class ProxiedHttpClientFactory : DefaultHttpClientFactory
	{
		private readonly string _proxyAddress;
		private readonly int _proxyPort;
		
		public ProxiedHttpClientFactory(string proxyAddress, int proxyPort)
		{
			this._proxyAddress = proxyAddress;
			this._proxyPort = proxyPort;
		}
		
		public override HttpMessageHandler CreateMessageHandler()
		{
			return new HttpClientHandler
			{
				Proxy = new WebProxy(this._proxyAddress, this._proxyPort),
				UseProxy = true
			};
		}
	}

	public sealed class Configuration : IConfiguration
	{
		public string UriScheme => this.Url.Scheme;
		public string UriHost => this.Url.Host;
		public int UriPort => this.Url.Port;
		private Uri Url => HttpContext.Current.Request.Url;
	}

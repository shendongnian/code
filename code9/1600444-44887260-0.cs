	public class CustomThrottlingHandler : ThrottlingHandler
	{
		public CustomThrottlingHandler(ThrottlePolicy policy, IPolicyRepository policyRepository, IThrottleRepository repository, IThrottleLogger logger, IIpAddressParser ipAddressParser = null)
			: base(policy, policyRepository, repository, logger, ipAddressParser)
		{
		}
		protected override RequestIdentity SetIdentity(HttpRequestMessage request)
		{
			return new RequestIdentity
			{
				ClientKey = request.Headers.Contains("my-header") ? request.Headers.GetValues("my-header").First() : "anon",
				ClientIp = base.GetClientIp(request).ToString(),
				Endpoint = request.RequestUri.AbsolutePath.ToLowerInvariant()
			};
		}
	}

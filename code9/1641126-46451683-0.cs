		private IMemoryCache memoryCache { get; set; }
		public HmacAuthenticationHandler(IOptionsMonitor<HmacAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IMemoryCache memCache)
			: base(options, logger, encoder, clock)
		{
			memoryCache = memCache;
		}

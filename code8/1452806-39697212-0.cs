	public static class HttpRequestMessageExtensions
	{
		private const string LogId = "LOG_ID";
		public static void SetLogId(this HttpRequestMessage request, Guid id)
		{
			request.Properties[LogId] = id;
		}
		public static Guid GetLogId(this HttpRequestMessage request)
		{
			object value;
			if (request.Properties.TryGetValue(LogId, out value))
			{
				return (Guid) value;
			}
			return Guid.Empty;
		}
	}

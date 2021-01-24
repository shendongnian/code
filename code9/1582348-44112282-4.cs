	namespace TwitchCSharp.Clients
	{
		public class TwitchTmiClient : ITwitchClient
		{
			public readonly RestClient restClient;
			public TwitchTmiClient(string url = TwitchHelper.TwitchTmiUrl)
			{
				restClient = new RestClient(url);
				restClient.AddHandler("application/json", new DynamicJsonDeserializer());
				restClient.AddHandler("text/html", new DynamicJsonDeserializer());
				restClient.AddDefaultHeader("Accept", TwitchHelper.twitchAcceptHeader);
			}
			public ViewerList GetChannelViewers(string channel)
			{
				var request = new RestRequest("group/user/{channel}/chatters");
				request.AddUrlSegment("channel", channel.ToLower());
				return restClient.Execute<ViewerList>(request).Data;
			}
			public RestRequest GetRequest(string url, Method method)
			{
				return new RestRequest(url, method);
			}
		}
	}

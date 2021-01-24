	namespace TwitchCSharp.Models
	{
		public class ViewerList
		{
			[JsonProperty("_links")]
			public Dictionary<string, string> Links;
			[JsonProperty("chatter_count")]
			public int ChatterCount;
			[JsonProperty("chatters")]
			public Chatter Chatters;
		}
	}
...
	namespace TwitchCSharp.Models
	{
		public class Chatter
		{
			[JsonProperty("moderators")] public string[] Moderators;
			[JsonProperty("staff")] public string[] Staff;
			[JsonProperty("admins")] public string[] Admins;
			[JsonProperty("global_mods")] public string[] GlobalMods;
			[JsonProperty("viewers")] public string[] Viewers;
		}
	}

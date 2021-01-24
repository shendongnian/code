		public class AuthenticationInfos
		{
			[JsonProperty(PropertyName = "username")]
			public string Username { get; set; }
			[JsonProperty(PropertyName = "password")]
			public string Password { get; set; }
			[JsonProperty(PropertyName = "Api-Key")]
			public string ApiKey { get; set; }
		}

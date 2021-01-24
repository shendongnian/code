	public abstract class AbstractTriggerRequest
	{
		[JsonProperty("userAttributes")]
		public Dictionary<string, string> UserAttributes { get; set; }
	}
	public abstract class AbstractTriggerResponse
	{
	}
	public class TriggerCallerContext
	{
		[JsonProperty("awsSdkVersion")]
		public string AwsSdkVersion { get; set; }
		[JsonProperty("clientId")]
		public string ClientId { get; set; }
	}
	public abstract class AbstractTriggerBase<TRequest, TResponse>
		where TRequest: AbstractTriggerRequest
		where TResponse: AbstractTriggerResponse
	{
		[JsonProperty("version")]
		public int Version { get; set; }
		[JsonProperty("triggerSource")]
		public string TriggerSource { get; set; }
		[JsonProperty("region")]
		public string Region { get; set; }
		[JsonProperty("userPoolId")]
		public string UserPoolId { get; set; }	
		[JsonProperty("callerContext")]
		public TriggerCallerContext CallerContext { get; set; }
		[JsonProperty("request")]
		public TRequest Request { get; set; }
		[JsonProperty("response")]
		public TResponse Response { get; set; }
		[JsonProperty("userName", NullValueHandling = NullValueHandling.Ignore)]
		public string UserName { get; set; }
	}
	public class PreSignUpSignUpRequest : AbstractTriggerRequest
	{
		[JsonProperty("validationData")]
		public Dictionary<string,string> ValidationData { get; set; }
	}

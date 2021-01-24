	public class AuthContent
	{
		public string auth_hash { get; set; }
	}
    string json = PerformAuthCall();
	var deserialized = JsonConvert.DeserializeObject<ResponseContainer<AuthContent>>(json);

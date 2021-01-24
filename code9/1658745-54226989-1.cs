	[SerializeField] private string auth_token;
	public string authToken { get { return auth_token; } }
	
	public static TokenResponse CreateFromJSON(string json) {
		return JsonUtility.FromJson<TokenResponse>(json);
	}
}
~~~

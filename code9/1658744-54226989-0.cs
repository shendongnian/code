	[SerializeField] private string auth_token;
	public string AuthToken { get { return auth_token; } }
	
	public static TokenResponse CreateFromJSON(string json) {
		return JsonUtility.FromJson<TokenResponse>(json);
	}
}
~~~

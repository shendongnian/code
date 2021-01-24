    [System.Serializable]
    public class TokenResponse
    {
        [NonSerialized]
        public string AuthToken;
        public string auth_token { get { return AuthToken; } }
        
        public static TokenResponse CreateFromJSON(string json)
        {
            return JsonUtility.FromJson<TokenResponse>(json);
        }
    }

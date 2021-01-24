    /// <summary>
    /// Contains access_token of a Facebook user.
    /// </summary>
    [DataContract]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Facebook", Justification = "Brand name")]
    public class FacebookAccessTokenData
    {
        #region Public Properties
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "token_type")]
        public string TokenType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "expires_in")]
        public string ExpiresIn { get; set; }
        #endregion
    }
	/// <summary>
	/// Obtains an access token given an authorization code and callback URL.
	/// </summary>
	/// <param name="returnUrl">
	/// The return url.
	/// </param>
	/// <param name="authorizationCode">
	/// The authorization code.
	/// </param>
	/// <returns>
	/// The access token.
	/// </returns>
	protected override string QueryAccessToken(Uri returnUrl, string authorizationCode) {
		// Note: Facebook doesn't like us to url-encode the redirect_uri value
		var builder = new UriBuilder(TokenEndpoint);
		builder.AppendQueryArgs(
			new Dictionary<string, string> {
				{ "client_id", this.appId },
				{ "redirect_uri", NormalizeHexEncoding(returnUrl.AbsoluteUri) },
				{ "client_secret", this.appSecret },
				{ "code", authorizationCode },
				{ "scope", "email" },
			});
		FacebookAccessTokenData graphData;
		var request = WebRequest.Create(builder.Uri);
		using (var response = request.GetResponse())
		{
			using (var responseStream = response.GetResponseStream())
			{
				graphData = JsonHelper.Deserialize<FacebookAccessTokenData>(responseStream);
			}
		}
		return graphData.AccessToken;
	}

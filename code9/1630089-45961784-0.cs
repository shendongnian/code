    public class CustomUserSession : AuthUserSession
    {
        [DataMember]
        public string CustomInfo { get; set; }
        public override void OnAuthenticated(IServiceBase authService, IAuthSession session, 
            IAuthTokens tokens, Dictionary<string, string> authInfo)
        {
            var unAuthInfo = authService.GetSessionBag().Get<UnAuthInfo>();
            if (unAuthInfo != null)
                this.CustomInfo = unAuthInfo.CustomInfo;
        }
    }

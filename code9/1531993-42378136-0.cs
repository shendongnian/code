    private static readonly ClaimsPrincipal user = System.Web.HttpContext.Current.GetOwinContext().Authentication.User as ClaimsPrincipal;
    private static readonly IEnumerable<Claim> claims = user.Claims;
    public static CustomUserInfo Idenitiy
    {
        get
        {
            UserInfo user = new UserInfo()
            {
                Custom1 = claims.Where(c => c.Type == Constants.ClaimsConstants.1customClaim).First().Value,
                Custom2 = claims.Where(c => c.Type == Constants.ClaimsConstants.2customClaim).First().Value
            };
         return user;
         }
     }

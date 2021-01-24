    using System.Security.Claims;
    using System.Web;
    using System.Web.Security;
    private bool IsAnonymousAccessAllowed => UrlAuthorizationModule.CheckUrlAccessForPrincipal(
        HttpContext.Current.Request.Path, 
        AnonymousClaimsPrincipal, 
        HttpContext.Current.Request.RequestType
    );

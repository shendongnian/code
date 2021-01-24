    public class ClaimsContextDataProvider : IUserContextDataProvider
        {
            public Guid UserId
            {
                get
                {
                    var userId = (Thread.CurrentPrincipal as ClaimsPrincipal)?.FindFirst(ClaimTypes.Sid)?.Value;
                    return TryGetGuidFromString(userId);
                }
            }
    }

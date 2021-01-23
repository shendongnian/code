    public class ZumoUserIdProvider : IUserIdProvider
    {
        public string GetUserId(IRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
    
            if (request.User != null && request.User.Identity != null)
            {
                var identity = (ClaimsIdentity)request.User.Identity;
                var identifier = identity.FindFirst(ClaimTypes.NameIdentifier);
                if (identifier != null)
                {
                    return identifier.Value;
                }
            }
    
            return null;
        }
    }

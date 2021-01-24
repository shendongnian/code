    public class CustomAuthorizationService: ICustomAuthorizationService {
        private readonly IAuthorizationService service;
        public CustomAuthorizationService(IAuthorizationService service) {
            this.service = service;
        }
        public Task<bool> AuthorizeAsync(ClaimsPrincipal user, string policyName) {
            return service.AuthorizeAsync(user, policyName);
        }
    }

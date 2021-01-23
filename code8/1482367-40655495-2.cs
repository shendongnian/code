    public class AuthenticationServiceFactory: IAuthenticationServiceFactory
    {
         private readonly AuthenticationService _authenticationService;
         private readonly NoAuthService_noAuthService;
         public AuthenticationServiceFactory(AuthenticationService authenticationService, NoAuthService noAuthService)
         {
             _noAuthService = noAuthService;
             _authenticationService = authenticationService;
         }
         public IAuthenticationService GetAuthenticationService()
         {
              if(settings.Authentication == false)
              {
                 return _noAuthService;
              }
              else
              {
                  return _authenticationService;
              }
         }
    }

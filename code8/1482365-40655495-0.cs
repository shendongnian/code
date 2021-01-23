    public class AuthenticationServiceGetter: IAuthenticationServiceGetter
    {
         private readonly AuthenticationService _authenticationService;
         private readonly NoAuthService_noAuthService;
         public AuthenticationServiceGetter(AuthenticationService authenticationService, NoAuthServicenoAuthService)
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

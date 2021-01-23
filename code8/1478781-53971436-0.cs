    namespace GoogleProxy
    {
    public class GoogleService
    {
        public CalendarService calendarService { get; private set; }
        public DriveService driveService { get; private set; }
        
        public GoogleService()
        {
            
        }
        public void Initialize(AuthResult authResult)
        {
            var credential = GetCredentialForApi(authResult);
            var baseInitializer = new BaseClientService.Initializer { HttpClientInitializer = credential, ApplicationName = "{your app name here}" };
            
            calendarService = new Google.Apis.Calendar.v3.CalendarService(baseInitializer);
            driveService = new Google.Apis.Drive.v3.DriveService(baseInitializer);
        }
        private UserCredential GetCredentialForApi(AuthResult authResult)
        {
            var initializer = new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = "{your app client id here}",
                    ClientSecret = "",
                },
                Scopes = new string[] { "openid", "email", "profile",  "https://www.googleapis.com/auth/calendar.readonly", "https://www.googleapis.com/auth/calendar.events.readonly", "https://www.googleapis.com/auth/drive.readonly" },
            };
            var flow = new GoogleAuthorizationCodeFlow(initializer);
            var token = new TokenResponse()
            {
                AccessToken = authResult.AccessToken,
                RefreshToken = authResult.RefreshToken,
                ExpiresInSeconds = authResult.ExpirationInSeconds,
                IdToken = authResult.IdToken,
                IssuedUtc = authResult.IssueDateTime,
                Scope = "openid email profile https://www.googleapis.com/auth/calendar.readonly https://www.googleapis.com/auth/calendar.events.readonly https://www.googleapis.com/auth/drive.readonly",
                TokenType = "bearer" };
            return new UserCredential(flow, authResult.Id, token);
        }
    }
    }

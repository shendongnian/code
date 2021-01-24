    public class ExampleController : Controller
    {
        // I'm assuming you have some sort of service that can read users from and update users to your database
        private IUserService userService;
    
        public ExampleController(IUserService userService)
        {
            this.userService = userService;
        }
    
        public async Task<IActionResult> Index()
        {
            var userId = // Get your user's ID however you get it
            
            // I'm assuming you have some way of knowing if a user has an access token for YouTube or not
            var userHasToken = this.userService.UserHasYoutubeToken(userId);
            var model = new ExampleModel { UserHasYoutubeToken = userHasToken }
            return View(model);
        }
    
        // This is a method we'll use to obtain the authorization code flow
        private AuthorizationCodeFlow GetGoogleAuthorizationCodeFlow(params string[] scopes)
        {
            var clientIdPath = @"C:\Path\To\My\client_id.json";
            using (var fileStream = new FileStream(clientIdPath, FileMode.Open, FileAccess.Read))
            {
                var clientSecrets = GoogleClientSecrets.Load(stream).Secrets;
                var initializer = new GoogleAuthorizationCodeFlow.Initializer { ClientSecrets = clientSecrets, Scopes = scopes };
                var googleAuthorizationCodeFlow = new GoogleAuthorizationCodeFlow(initializer);
    
                return googleAuthorizationCodeFlow;
            }
        }
    
        // This is a route that your View will call (we'll call it using JQuery)
        [HttpPost]
        public async Task<string> GetAuthorizationUrl()
        {
            // First, we need to build a redirect url that Google will use to redirect back to the application after the user grants access
            var protocol = Request.IsHttps ? "https" : "http";
            var redirectUrl = $"{protocol}://{Request.Host}/{Url.Action(nameof(this.GetYoutubeAuthenticationToken)).TrimStart('/')}";
    
            // Next, let's define the scopes we'll be accessing. We are requesting YouTubeForceSsl so we can manage a user's YouTube account.
            var scopes = new[] { YouTubeService.Scope.YoutubeForceSsl };
    
            // Now, let's grab the AuthorizationCodeFlow that will generate a unique authorization URL to redirect our user to
            var googleAuthorizationCodeFlow = this.GetGoogleAuthorizationCodeFlow(scopes);
            var codeRequestUrl = googleAuthorizationCodeFlow.CreateAuthorizationCodeRequest(redirectUrl);
            codeRequestUrl.ResponseType = "code";
    
            // Build the url
            var authorizationUrl = codeRequestUrl.Build();
    
            // Give it back to our caller for the redirect
            return authorizationUrl;
        }
    
        public async Task<IActionResult> GetYoutubeAuthenticationToken([FromQuery] string code)
        {
            if(string.IsNullOrEmpty(code))
            {
                /* 
                    This means the user canceled and did not grant us access. In this case, there will be a query parameter
                    on the request URL called 'error' that will have the error message. You can handle this case however.
                    Here, we'll just not do anything, but you should write code to handle this case however your application
                    needs to.
                */
            }
    
            // The userId is the ID of the user as it relates to YOUR application (NOT their Youtube Id).
            // This is the User ID that you assigned them whenever they signed up or however you uniquely identify people using your application
            var userId = // Get your user's ID however you do (whether it's on a claim or you have it stored in session or somewhere else)
            
            // We need to build the same redirect url again. Google uses this for validaiton I think...? Not sure what it's used for
            // at this stage, I just know we need it :)
            var protocol = Request.IsHttps ? "https" : "http";
            var redirectUrl = $"{protocol}://{Request.Host}/{Url.Action(nameof(this.GetYoutubeAuthenticationToken)).TrimStart('/')}";
    
            // Now, let's ask Youtube for our OAuth token that will let us do awesome things for the user
            var scopes = new[] { YouTubeService.Scope.YoutubeForceSsl };
            var googleAuthorizationCodeFlow = this.GetYoutubeAuthorizationCodeFlow(scopes);
            var token = await googleAuthorizationCodeFlow.ExchangeCodeForTokenAsync(userId, code, redirectUrl, CancellationToken.None);
    
            // Now, you need to store this token in rlation to your user. So, however you save your user data, just make sure you
            // save the token for your user. This is the token you'll use to build up the UserCredentials needed to act on behalf
            // of the user.
            var tokenJson = JsonConvert.SerializeObject(token);
            await this.userService.SaveUserToken(userId, tokenJson);
    
            // Now that we've got access to the user's YouTube account, let's get back
            // to our application :)
            return RedirectToAction(nameof(this.Index));
        }
    }

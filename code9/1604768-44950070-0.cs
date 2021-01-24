    public class HomeController : Controller
        {
            public ActionResult ValidateTwitterAuth()
            {
                Session["verifierCode"] = Request.Query.ElementAt(2).Value;
                //do some stuff
            }
            public String sendTweet(String NewTweet)
            {
                var userCreds = AuthFlow.CreateCredentialsFromVerifierCode(Session["verifierCode"], Container.authorizationId);
                var user = Tweetinvi.User.GetAuthenticatedUser(userCreds);
                user.PublishTweet(NewTweet);
                return "sent!";
            }
        }

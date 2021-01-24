    public class WellKnownFileController : Controller
    {
        public WellKnownFileController()
        {
        }
        [Route(".well-known/apple-developer-merchantid-domain-association")]
        public ContentResult AppleMerchantIDDomainAssociation()
        {
            switch (Request.Host.Host)
            {
                case "www2.example.com":
                    return new ContentResult
                    {
                        Content = @"7B227073323935343637",
                        ContentType = "text/text"
                    };
                default:
                    throw new Exception("Unregistered domain!");
            }
        }
    }

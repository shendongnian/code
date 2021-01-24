    public class WebApiWithAuthenticationTests : WebApiTestsBase
    {    
        public WebApiWithAuthenticationTests()
            : base(new ODataClientSettings()
            {
                BaseUri = new Uri("http://va-odata-integration.azurewebsites.net/odata/secure"), 
                Credentials = CredentialCache.DefaultCredentials
            })
        {
        }
    }

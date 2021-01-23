    public void Web_Login_ShouldValidateUserAndLoginSuccessfully()
        {
            using (var kernel = new NSubstituteMockingKernel())
            {
                // Setup the dependency incjection
                kernel.Load(new EntityFrameworkTestingNSubstituteModule());
    
                // Create test request data 
                var request = new LogInRequest { UserName = "test", Password = "test" };
    
                var fakeResponseHandler = new FakeResponseHandler();
                fakeResponseHandler.AddFakeResponse(new Uri("http://localhost/test"), new HttpResponseMessage(HttpStatusCode.OK));
                ConfigurationManager.AppSettings["SearchApiBaseUrl"] = "http://dev.loans.carfinance.com/internal";
                var server = new HttpServer(new HttpConfiguration(), fakeResponseHandler);
                var httpClient = new HttpClient(server);
                var controller = new LoanDriverController(httpClient);
                controller.CookieManager=mockOfYourCookieManager; //here you pass the instance of the mock or also you can passe it in the constructor of the controller.
                Fake.SetFakeContext(controller);
                var result = controller.Login(request);
                Assert.IsNotNull(result);
            }

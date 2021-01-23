    [Test]
    public void Analyze_WebServiceThrows_SendsEmail_Modified()
    {
        var stubWebService = MockRepository.GenerateMock<IWebService>();
        var mockEmailService = MockRepository.GenerateMock<IEmailService>();
        var logAnalyzerDynamicMockWithEmail = new LogAnalyzerDynamicMockWithEmail
        {
            Service = stubWebService,
            Email = mockEmailService
        };
        // Set up our expectations
        stubWebService.Expect(m => m.LogError("whatever")).IgnoreArguments().Throw(new Exception("fake exception"));
        mockEmailService.Expect(m => m.SendEmail("a", "subject", "fake exception")).Repeat.Once();
        logAnalyzerDynamicMockWithEmail.Analyze("abc.ext");
        // Verify our SendEmail method was called
        mockEmailService.VerifyAllExpectations();
    }

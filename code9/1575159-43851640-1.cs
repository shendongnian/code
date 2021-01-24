     using (var svc = new AnalyticsReportingService(
         new BaseClientService.Initializer
     {
         HttpClientInitializer = credential,
         ApplicationName = "Google Analytics API Console",
         HttpClientFactory = new CustomHttpClientFactory()
     }))

     private static async Task Run()
        {
            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = Settings.Default.ClientId,
                    ClientSecret = Settings.Default.ClientSecret
                },
                new[] {AnalyticsReportingService.Scope.AnalyticsReadonly},
                "user",
                CancellationToken.None);
            var service = new AnalyticsReportingService(new BaseClientService.Initializer
            {
                ApplicationName = "GAReportDownloader",
                HttpClientInitializer = credential
            });
            // Content here
            Console.WriteLine("Hello from Google Analytics. Starting..");
            // Create the DateRange object.
            var dateRange = new DateRange {StartDate = "2017-07-01", EndDate = "2017-07-10"};
            // Create the Metrics object.
            var sessions = new Metric {Expression = "ga:sessions", Alias = "Sessions"};
            //Create the Dimensions object.
            var browser = new Dimension {Name = "ga:browser"};
            // Create the ReportRequest object.
            var reportRequest = new ReportRequest
            {
                ViewId = "YOURVIEWIDHERE",
                DateRanges = new List<DateRange> {dateRange},
                Dimensions = new List<Dimension> {browser},
                Metrics = new List<Metric> {sessions}
            };
            var requests = new List<ReportRequest> {reportRequest};
            // Create the GetReportsRequest object.
            var getReport = new GetReportsRequest {ReportRequests = requests};
            // Call the batchGet method.
            var response = service.Reports.BatchGet(getReport).Execute();
            Console.WriteLine();
        }
    }

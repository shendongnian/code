     ClientSecrets cs = new ClientSecrets
            {
                ClientId = "Put_Your_Client_Id_Here",
                ClientSecret = "Put_Your_Client_Secret_Here"
            };
            string ApplicationName = "Google Calendar API .NET Quickstart";
             //Path where Json File is stored
            FileDataStore store = new FileDataStore(System.Web.HttpContext.Current.Server.MapPath("~/Uploads/Template/credentials/calendar-dotnet-quickstart.json/calendar-dotnet-quickstart.json"), true);
            UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(cs, Scopes, "user", CancellationToken.None, store).Result;
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

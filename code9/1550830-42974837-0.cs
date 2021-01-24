    string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
    credPath = Path.Combine(credPath, ".credentials/", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
    var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
            new ClientSecrets
            {
                ClientId = "xxx4671204-9khdjsqifkj2amsji2jce37p8lfn0166.apps.googleusercontent.com",
                ClientSecret = "ZdsrCa-uwG3GmpVLTfYDli-S",
            },
            new[] { CalendarService.Scope.Calendar },
            "user",
            CancellationToken.None,
            new FileDataStore(credPath, true)).Result;

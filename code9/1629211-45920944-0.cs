       private async Task Run()
        {   
            UserCredential credential;
            using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { BooksService.Scope.Books },
                    "user", CancellationToken.None, new FileDataStore("Books.ListMyLibrary"));
            }
            // Create the service.
            var service = new BooksService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Books API Sample",
                });
            var bookshelves = await service.Mylibrary.Bookshelves.List().ExecuteAsync();
            ...
        }

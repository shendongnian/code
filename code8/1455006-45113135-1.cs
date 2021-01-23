            service = new FusiontablesService(
                new BaseClientService.Initializer()
                {
                    HttpClientInitializer = creds,
                    ApplicationName = "Street Parking",
                });

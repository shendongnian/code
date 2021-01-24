            RestClient client = new RestClient(_freshdeskUrl);
            client.Authenticator = new HttpBasicAuthenticator(_apiKey, "X");
            RestRequest request = new RestRequest("", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(new
            {
                email = "example@example.com",
                subject = "Subject",
                description = "Description",
                name = "Name",
                status = 2,
                priority = 1
            });
            var response = client.Execute(request);

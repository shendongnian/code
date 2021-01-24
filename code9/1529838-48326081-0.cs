            var client = new HttpClient();
            client.BaseAddress = new Uri("http://example.com/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            services.AddSingleton<HttpClient>(client);
...
            var incoming = new Uri(uri, UriKind.Relative); // Don't let the user specify absolute.
            var response = await _client.GetAsync(incoming);

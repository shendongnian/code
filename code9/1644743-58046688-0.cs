    var client = new HttpClient();
        var accessToken = await HttpContext
            .GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
        var disco = await client.GetDiscoveryDocumentAsync("https://localhost:44323");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        var response = await client.GetUserInfoAsync(new UserInfoRequest
        {
            Address = disco.UserInfoEndpoint,
            Token = accessToken
        });
        var address = response.Claims.FirstOrDefault(c => c.Type == "address")?.Value;
        var add = new AddressViewModel();
        add.Address = address;
        return View(add);

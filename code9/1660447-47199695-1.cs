      // Get UserInfo
      var client = new HttpClient();
      client.SetBearerToken(tokenResponse.AccessToken);
      var response = await client.GetAsync(disco.UserInfoEndpoint);
      if (!response.IsSuccessStatusCode)
      {
        Console.WriteLine(response.StatusCode);
      }
      else
      {
        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(JArray.Parse(content));
      }

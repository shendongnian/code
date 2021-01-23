    var encodedAuth = System.Convert.ToBase64String(
        System.Text.Encoding.UTF8.GetBytes("username:password")
    );
    var Client = new HttpClient();
    Client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuth);

    string username = "{username}";
    string password = "{password}";
    string jobname = "{your-webjob-name}";
    string authorization = Convert.ToBase64String(System.Text.UTF8Encoding.UTF8.GetBytes($"{username}:{password}"));
    using (var client = new HttpClient())
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorization);
        var res = await client.PostAsync($"https://{your-webapp-name}.scm.azurewebsites.net/api/continuouswebjobs/{jobname}/stop", null);
        Console.WriteLine($"StatusCode:{res.StatusCode}");
    }

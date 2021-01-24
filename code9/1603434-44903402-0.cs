    public async Task Notify(string message)
    {
       var string url = "MY_WEBSERVICE_URL";
       var client = new HttpClient();
       client.BaseAddress = new Uri(url);
       var notification = new Notification { Text = message }; // use some model class
       var resonse = await client.PostAsJsonAsync("relativeAddress", notification);
       if (response.IsSuccessStatusCode)
       {
           var content = await response.Content.ReadAsStringAsync();
       }
    }

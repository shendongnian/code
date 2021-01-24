    using (var client = new WebClient())
    {
        var url = "https://api.amplitude.com/httpapi";
        client.Headers[HttpRequestHeader.ContentType] = "application/json";
        var model = new { user_id = "userId", event_type = "Event" };
        var jss = new JavaScriptSerializer();
        var data = jss.Serialize(model);
        string parameters = "api_key=" + "apiKey" + "&event=" + System.Uri.EscapeDataString(data);
        var response = client.DownloadString ($"{url}?{parameters}");
    }

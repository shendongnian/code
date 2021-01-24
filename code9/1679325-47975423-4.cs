        var message = new HttpRequestMessage(HttpMethod.Put, new Uri(WebConfigurationManager.AppSettings["dossier"] + "api/dossier?clientId=" + clientId));
        message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        using (var response = await Client.SendAsync(message))
        {
             // ...
        }

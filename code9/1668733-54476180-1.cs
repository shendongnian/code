    public WebClient GetRabbitMqConnection(string userName, string password)
    {
        var client = new WebClient(); 
        client.Credentials = new NetworkCredential(userName, password);
        return client;
    }

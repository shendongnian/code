    using (WebClient client = new WebClient())
    {
        client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
        client.Headers.Add(HttpRequestHeader.Authorization, "Bot [Redacted]");
        string output = client.UploadString
        (
            "https://discordapp.com/api/guilds/[GuildID]/members/[UserID]",
            WebRequestMethods.Http.Put,
            "{\"access_token\":\"[Redacted]\"}"
        );
    }

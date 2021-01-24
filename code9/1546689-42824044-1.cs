    static void Main(string[] args)
    {
        DiscordClient client = null;
        // initialize client etc here.
        string twitchStreamId = "";
        string twitchApiKey = "";
        string discordServerName = "";
        string discordChannelName = "";
        // find discord channel
        var server = client.FindServers(discordServerName).FirstOrDefault();
        var channel = server.FindChannels(discordChannelName, ChannelType.Text).FirstOrDefault();
        var lastTwitchStatus = CheckTwitchStatusIsOnline(twitchStreamId, twitchApiKey);
        // send a message on startup always
        SendDiscordChannelMessage(channel, lastTwitchStatus);
        while (true)
        {
            // check the status every 10 seconds after that and if the status has changed we send a message
            Thread.Sleep(10000);
            var status = CheckTwitchStatusIsOnline(twitchStreamId, twitchApiKey);
            // if the status has changed since the last time we checked, send a message
            if (status != lastTwitchStatus)
                SendDiscordChannelMessage(channel, status);
            lastTwitchStatus = status;
        }
    }
    private static void SendDiscordChannelMessage(Channel channel, bool twitchIsOnline)
    {
        channel.SendMessage(twitchIsOnline ? "Twitch channel is now live!!" : "Twitch channel is now offline :(");
    }
    private static bool CheckTwitchStatusIsOnline(string streamId, string twitchApiKey)
    {
        // send a request to twitch and check whether the stream is live.
        var url = "https://api.twitch.tv/kraken/streams/" + streamId;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.Timeout = 12000;
        request.ContentType = "application/json";
        request.Headers.Add("authorization", twitchApiKey);
        using (var sr = new StreamReader(request.GetResponse().GetResponseStream()))
        {
            var jsonObject = JObject.Parse(sr.ReadToEnd());
            var jsonStream = jsonObject["stream"];
            // twitch channel is online if stream is not null.
            var twitchIsOnline = jsonStream.Type != JTokenType.Null;
            return twitchIsOnline;
        }
    }

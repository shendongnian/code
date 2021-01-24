    namespace MyFirstBot
    {
        public class DiscordBot
        {
            DiscordClient client;
            CommandService commands;
            TwitchClient TwitchClient;
            TwitchAPIexample twitchLive = new TwitchAPIexample();
            public DiscordBot()
            {
                if(twitchLive.Root == null || twitchLive.Root.Stream == null)
                {
                    //stream is offline
                }
            }
        }
    }

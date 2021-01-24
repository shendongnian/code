    using System;
    using Discord;
    class Program
    {
        static public DiscordClient client;
        static void Main(string[] args)
        {
            client = new DiscordClient(input =>
            {
                input.LogLevel = LogSeverity.Info;
            });
            client.MessageReceived += Client_MessageReceived;
            client.ExecuteAndWait(async () =>
            {
                await client.Connect("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", TokenType.Bot);
            });
        }
        static async private void Client_MessageReceived(object sender, MessageEventArgs e)
        {
            if (e.Message.Text == "no u")
                await e.Channel.SendMessage("You have the mentality of a five year old");
        }
    }

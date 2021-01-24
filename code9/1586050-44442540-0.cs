     public static async void OnMessageReceived(object sender, MessageEventArgs e)
        {
            if (e.Message.Text.Contains(toBlacklist.ToString()))
            {
                Message[] blacklistedMessagesToDelete;
                blacklistedMessagesToDelete = await e.Channel.DownloadMessages(1);
                await e.Channel.DeleteMessages(blacklistedMessagesToDelete);
            }
        }

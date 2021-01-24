        private async Task OnMessageReceived(SocketMessage msg)
        {
            foreach (var word in blacklistedWords)
            {
                if (msg.Content.Contains(word))
                {
                    var messagesToDelete = await msg.Channel.GetMessagesAsync(1).Flatten();
                    await msg.Channel.DeleteMessagesAsync(messagesToDelete);
                }
            }
        }

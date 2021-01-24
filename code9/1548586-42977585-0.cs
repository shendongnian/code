        const ulong serverId = 38297389272897UL; // the id of your server
        const ulong channelId = 78346982689343UL; // the id of the channel
        Server findServer(ulong id)
        {
            foreach(Server server in discord.Servers) // discord is your DiscorClient instance
            {
                if (server.Id == serverId)
                    return server;
            }
            return null;
        }
        Channel findTextChannel(Server server, ulong id)
        {
            foreach(Channel channel in server.TextChannels)
            {
                if (channel.Id == channelId)
                    return channel;
            }
            return null;
        }
        private Channel channel;
        private System.Threading.Timer timer;
        void load()
        {
            Server server = findServer(serverId);
            if (server != null)
            {
                channel = findTextChannel(server, channelId);
                if (channel != null)
                    timer = new System.Threading.Timer(send, null, 0, 1000 * 60 * 60 * 24); // 24 hour interval
            }
        }
        void send(object state)
        {
            channel.SendMessage("your message");
        }

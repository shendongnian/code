    public async Task DispatchAsync(NoticeChannelType type, string message)
    {
        var channelType = _context.ResolveKeyed<INoticeChannel>(type).GetType();
        var channel = JsonConvert.DeserializeObject(message, channelType);
        await (Task)_channelResolver.ResolveAsync((dynamic)channel);
    }

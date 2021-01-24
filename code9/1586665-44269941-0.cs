    public async Task DispatchAsync(NoticeChannelType type, string message)
    {
        var channelType = _context.ResolveKeyed<INoticeChannel>(type).GetType();
        var channel = JsonConvert.DeserializeObject(message, channelType);
        var resolveMethod = _channelResolver.GetType().GetMethod("ResolveAsync")
            .MakeGenericMethod(channelType);
        await (Task)resolveMethod.Invoke(_channelResolver, new object[] { channel });
    }

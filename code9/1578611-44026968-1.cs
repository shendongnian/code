    if (incomingMessage.TryGetChannelData(out FacebookChannelData channelDataInfo))
    {
        return channelDataInfo.RefParameter;
    }
    else
    {
        return String.Empty;
    }

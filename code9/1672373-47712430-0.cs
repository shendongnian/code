    [ComEventInterface(typeof(IChannelEvents), typeof(IChannelEvents_EventProvider)), ComVisible(false), TypeLibType(16)]
    public interface IChannelEvents_Event
    {
      event IChannelEvents_OnlineValueEventHandler OnlineValue;
      event IChannelEvents_MeasuredExcitationEventHandler MeasuredExcitation;
      event IChannelEvents_MultipleOnlineValuesEventHandler MultipleOnlineValues;
    }

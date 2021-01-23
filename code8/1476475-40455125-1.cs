    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("77cf513e-5d49-4789-9f30-d0822b335c0d")]
    public interface IPrintAsyncNotifyDataObject
    {
        void AcquireData(out IntPtr data, out uint cbData, out IntPtr schema);
        void ReleaseData();
    }
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("4a5031b1-1f3f-4db0-a462-4530ed8b0451")]
    public interface IPrintAsyncNotifyChannel
    {
        void SendNotification(IPrintAsyncNotifyDataObject data);
        void CloseChannel(IPrintAsyncNotifyDataObject data);
    }
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("7def34c1-9d92-4c99-b3b3-db94a9d4191b")]
    public interface IPrintAsyncNotifyCallback
    {
        void OnEventNotify(IPrintAsyncNotifyChannel channel, IPrintAsyncNotifyDataObject data);
        void ChannelClosed(IPrintAsyncNotifyChannel channel, IPrintAsyncNotifyDataObject data);
    }
    public enum PrintAsyncNotifyUserFilter : uint
    {
        kPerUser = 0,
        kAllUsers = 1
    }
    public enum PrintAsyncNotifyConversationStyle : uint
    {
        kBiDirectional = 0,
        kUniDirectional = 1
    }

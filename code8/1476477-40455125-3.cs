    [DllImport("WINSPOOL.DRV", PreserveSig = false, ExactSpelling = true)]
    public static extern void RegisterForPrintAsyncNotifications(
        [MarshalAs(UnmanagedType.LPWStr)] string name,
        [MarshalAs(UnmanagedType.LPStruct)] Guid notificationType, PrintAsyncNotifyUserFilter filter,
        PrintAsyncNotifyConversationStyle converstationStyle,
        IPrintAsyncNotifyCallback callback, out PrintAsyncNotificationSafeHandle handle);
    [DllImport("WINSPOOL.DRV", PreserveSig = true, ExactSpelling = true)]
    public static extern int UnRegisterForPrintAsyncNotifications(IntPtr handle);
    public sealed class PrintAsyncNotificationSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public PrintAsyncNotificationSafeHandle()
            : base(true)
        {
        }
        protected override bool ReleaseHandle()
        {
            return UnRegisterForPrintAsyncNotifications(handle) == 0 /* S_OK */;
        }
    }

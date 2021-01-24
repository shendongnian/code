    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    internal sealed class Impersonator : IDisposable
    {
        #region Properties
        private SafeTokenHandle _handle;
        private WindowsImpersonationContext _context;
        private bool _isDisposed;
        public bool IsDisposed
        {
            get { return _isDisposed; }
            private set { _isDisposed = value; }
        }
        #endregion
        #region Constructors / Factory Methods
        private Impersonator(string domain, string userName, string password, LogonType logonType, LogonProvider provider)
        {
            bool gotTokenHandle = NativeLoginMethods.LogonUser(userName, domain, password, (int)logonType, (int)provider, out _handle);
            if (!gotTokenHandle || _handle.IsInvalid)
            {
                int errorCode = Marshal.GetLastWin32Error();
                throw new System.ComponentModel.Win32Exception(errorCode);
            }
        }
        public static Impersonator LogonUser(string domain, string userName, string password, LogonType logonType, LogonProvider provider)
        {
            Impersonator impersonator = new Impersonator(domain, userName, password, logonType, provider);
            impersonator._context = WindowsIdentity.Impersonate(impersonator._handle.DangerousGetHandle());
            return impersonator;
        }
        #endregion
        #region Dispose Pattern Methods
        private void Dispose(bool disposing)
        {
            //Allow the Dispose() to be called more than once
            if (this.IsDisposed)
                return;
            if (disposing)
            {
                // Cleanup managed wrappers
                if (_context != null)
                    _context.Dispose();
                if (_handle != null && !_handle.IsClosed)
                    _handle.Dispose();
                //Suppress future calls if successful
                this.IsDisposed = true;
            }
        }
        public void Dispose()
        {
            //Dispose the resource
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    internal class NativeLoginMethods
    {
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword, int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);
        [DllImport("kernel32.dll")]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CloseHandle(IntPtr handle);
    }
    internal sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        #region Constructors
        internal SafeTokenHandle()
            : base(true)
        { }
        #endregion
        #region Support Methods
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        protected override bool ReleaseHandle()
        {
            return NativeLoginMethods.CloseHandle(base.handle);
        }
        #endregion
    }
    /// <summary>
    /// Logon Type enum
    /// </summary>
    internal enum LogonType : int
    {
        /// <summary>
        /// This logon type is intended for users who will be interactively using the computer, such as a user being logged on by a terminal server, remote shell, or similar process. This logon type has the additional expense of caching logon information for disconnected operations; therefore, it is inappropriate for some client/server applications, such as a mail server.
        /// </summary>
        INTERACTIVE = 2,
        /// <summary>
        /// This logon type is intended for high performance servers to authenticate plaintext passwords. The LogonUser function does not cache credentials for this logon type.
        /// </summary>
        NETWORK = 3,
        /// <summary>
        /// This logon type is intended for batch servers, where processes may be executing on behalf of a user without their direct intervention. This type is also for higher performance servers that process many plaintext authentication attempts at a time, such as mail or web servers.
        /// </summary>
        BATCH = 4,
        /// <summary>
        /// Indicates a service-type logon. The account provided must have the service privilege enabled.
        /// </summary>
        SERVICE = 5,
        /// <summary>
        /// GINAs are no longer supported.  Windows Server 2003 and Windows XP:  This logon type is for GINA DLLs that log on users who will be interactively using the computer. This logon type can generate a unique audit record that shows when the workstation was unlocked.
        /// </summary>
        UNLOCK = 7,
        /// <summary>
        /// This logon type preserves the name and password in the authentication package, which allows the server to make connections to other network servers while impersonating the client. A server can accept plaintext credentials from a client, call LogonUser, verify that the user can access the system across the network, and still communicate with other servers.
        /// </summary>
        NETWORK_CLEARTEXT = 8,
        /// <summary>
        /// This logon type allows the caller to clone its current token and specify new credentials for outbound connections. The new logon session has the same local identifier but uses different credentials for other network connections. This logon type is supported only by the LOGON32_PROVIDER_WINNT50 logon provider.
        /// </summary>
        NEW_CREDENTIALS = 9
    }
    internal enum LogonProvider : int
    {
        /// <summary>
        /// Use the standard logon provider for the system. The default security provider is negotiate, unless you pass NULL for the domain name and the user name is not in UPN format. In this case, the default provider is NTLM.
        /// </summary>
        LOGON32_PROVIDER_DEFAULT = 0,
        /// <summary>
        /// Use the Windows NT 3.5 logon provider.
        /// </summary>
        LOGON32_PROVIDER_WINNT35 = 1,
        /// <summary>
        /// Use the NTLM logon provider.
        /// </summary>
        LOGON32_PROVIDER_WINNT40 = 2,
        /// <summary>
        /// Use the negotiate logon provider. 
        /// </summary>
        LOGON32_PROVIDER_WINNT50 = 3
    }

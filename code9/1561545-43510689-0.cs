     [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public class Impersonation : IDisposable
    {
        private readonly SafeTokenHandle _handle;
        private readonly WindowsImpersonationContext _context;
        bool disposed = false;
        const int LOGON32_PROVIDER_DEFAULT = 0;
        const int LOGON32_LOGON_INTERACTIVE = 2;
        public Impersonation(ImpersonateUserDetails user) : this(user.Domain, user.UserName, user.Password)
        { }
        public Impersonation(string domain, string username, string password)
        {
            var ok = LogonUser(username, domain, password,
                           LOGON32_LOGON_INTERACTIVE, 0, out this._handle);
            if (!ok)
            {
                var errorCode = Marshal.GetLastWin32Error();
                throw new ApplicationException(string.Format("Could not impersonate the elevated user.  LogonUser returned error code {0}.", errorCode));
            }
            this._context = WindowsIdentity.Impersonate(this._handle.DangerousGetHandle());
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                this._context.Dispose();
                this._handle.Dispose();
            }           
            disposed = true;
        }
        ~Impersonation()
        {
            Dispose(false);
        }
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword, int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);
        sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            private SafeTokenHandle()
                : base(true) { }
            [DllImport("kernel32.dll")]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            [SuppressUnmanagedCodeSecurity]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool CloseHandle(IntPtr handle);
            protected override bool ReleaseHandle()
            {
                return CloseHandle(handle);
            }
        }
    }
    public class ImpersonateUserDetails
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
    }

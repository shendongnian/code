     private Impersonate(bool active, string domain, string username, string password, LogonType logonType, LogonProvider logonProvider)
            {
                if (active)
                {
                    IntPtr handle;
                    var ok = NativeMethods.LogonUser(username, domain, password, (int)logonType, (int)logonProvider, out handle);
                    if (!ok)
                    {
                        var errorCode = Marshal.GetLastWin32Error();
                        throw new ApplicationException(string.Format("Could not impersonate the elevated user.  LogonUser returned error code {0}.", errorCode));
                    }
    
                    _handle = new SafeTokenHandle(handle);
                    _context = WindowsIdentity.Impersonate(_handle.DangerousGetHandle());
                }
            }

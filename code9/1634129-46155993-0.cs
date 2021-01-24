    class GetProxySettings
    {
        private const int INTERNET_OPTION_PROXY = 38;
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool InternetQueryOption(IntPtr hInternet, uint dwOption, IntPtr lpBuffer, ref int lpdwBufferLength);
        /// <summary>
        /// Access types supported by InternetOpen function.
        /// </summary>        
       private enum InternetOpenType
        {
            INTERNET_OPEN_TYPE_PRECONFIG = 0,
            INTERNET_OPEN_TYPE_DIRECT = 1,
            INTERNET_OPEN_TYPE_PROXY = 3,
        }
        /// <summary>
        /// Contains information that is supplied with the INTERNET_OPTION_PROXY value
        /// to get or set proxy information on a handle obtained from a call to 
        /// the InternetOpen function.
        /// </summary>
        private struct INTERNET_PROXY_INFO
        {
            public InternetOpenType DwAccessType
            {
                get; set;
            }
            public string LpszProxy
            {
                get; set;
            }
            public string LpszProxyBypass
            {
                get; set;
            }
        }
        internal string[] GetV(WindowsIdentity windowsIdentity)
        {
            string[] settings = new string[] { "", "" };
            using (windowsIdentity.Impersonate())
            {
                int bufferLength = 0;
                IntPtr buffer = IntPtr.Zero;
                InternetQueryOption(IntPtr.Zero, INTERNET_OPTION_PROXY, IntPtr.Zero,
                                    ref bufferLength);
                try
                {
                    buffer = Marshal.AllocHGlobal(bufferLength);
                    if (InternetQueryOption(IntPtr.Zero, INTERNET_OPTION_PROXY, buffer,
                                            ref bufferLength))
                    {
                        INTERNET_PROXY_INFO proxyInfo = (INTERNET_PROXY_INFO)
                        // Converting structure to IntPtr.
                        Marshal.PtrToStructure(buffer, typeof(INTERNET_PROXY_INFO));
                        // Getting the proxy details.
                        settings[0] = proxyInfo.LpszProxy.Split(':')[0];
                        settings[1] = proxyInfo.LpszProxy.Split(':')[1];
                    }
                }
                catch { }
            }
            return settings;
        }
    }

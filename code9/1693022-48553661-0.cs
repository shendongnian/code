    public class VisualStudioContext : IDisposable
    {
        public string VersionTag { get; }
        public string UserFolder { get; }
        public string PrivateRegistryPath { get; }
        public SafeRegistryHandle RegistryHandle { get; }
        public RegistryKey RootKey { get; }
        private static readonly Lazy<VisualStudioContext> LazyInstance = new Lazy<VisualStudioContext>(() => new VisualStudioContext());
        public static VisualStudioContext Instance => LazyInstance.Value;
        private VisualStudioContext()
        {
            try
            {
                string localAppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string vsFolder = $"{localAppDataFolder}\\Microsoft\\VisualStudio";
                var vsFolderInfo = new DirectoryInfo(vsFolder);
                DateTime lastDateTime = DateTime.MinValue;
                foreach (DirectoryInfo dirInfo in vsFolderInfo.GetDirectories("15.0_*"))
                {
                    if (dirInfo.CreationTime <= lastDateTime)
                        continue;
                    UserFolder = dirInfo.FullName;
                    lastDateTime = dirInfo.CreationTime;
                }
                if (UserFolder == null)
                    throw new Exception($"No Visual Studio folders found in \"{vsFolder}\"");
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to open Visual Studio folder", ex);
            }
            VersionTag = Path.GetFileName(UserFolder);
            PrivateRegistryPath = $"{UserFolder}\\privateregistry.bin";
            int handle = RegistryNativeMethods.RegLoadAppKey(PrivateRegistryPath);
            RegistryHandle = new SafeRegistryHandle(new IntPtr(handle), true);
            RootKey = RegistryKey.FromHandle(RegistryHandle);
        }
        public void Dispose()
        {
            RootKey?.Close();
            RegistryHandle?.Dispose();
        }
        public class Exception : ApplicationException
        {
            public Exception(string message) : base(message)
            {
            }
            public Exception(string message, Exception innerException) : base(message, innerException)
            {
            }
        }
        internal static class RegistryNativeMethods
        {
            [Flags]
            public enum RegSAM
            {
                AllAccess = 0x000f003f
            }
            private const int REG_PROCESS_APPKEY = 0x00000001;
            // approximated from pinvoke.net's RegLoadKey and RegOpenKey
            // NOTE: changed return from long to int so we could do Win32Exception on it
            [DllImport("advapi32.dll", SetLastError = true)]
            private static extern int RegLoadAppKey(String hiveFile, out int hKey, RegSAM samDesired, int options, int reserved);
            public static int RegLoadAppKey(String hiveFile)
            {
                int hKey;
                int rc = RegLoadAppKey(hiveFile, out hKey, RegSAM.AllAccess, REG_PROCESS_APPKEY, 0);
                if (rc != 0)
                {
                    throw new Win32Exception(rc, "Failed during RegLoadAppKey of file " + hiveFile);
                }
                return hKey;
            }
        }
    }

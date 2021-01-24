    public static class ProcessExtensions {
        [DllImport("Psapi.dll")]
        private static extern uint GetModuleFileNameEx([In] IntPtr hProcess, [In] IntPtr hModule, [Out] StringBuilder lpBaseName, [In] uint nSize);
    
        public static string GetMainModuleFileName(this Process process, int buffer = 1024) {
            var fileNameBuilder = new StringBuilder(buffer);
            uint code = Psapi.GetModuleFileNameEx(process.Handle, IntPtr.Zero, fileNameBuilder, (uint)fileNameBuilder.Capacity + 1);
            return code != 0 ?
                fileNameBuilder.ToString() :
                null;
        }
        public static Icon GetIcon(this Process process) {
            try {
                string mainModuleFileName = process.GetMainModuleFileName();
                return Icon.ExtractAssociatedIcon(mainModuleFileName);
            }
            catch {
                // Probably no access
                return null;
            }
        }
    }

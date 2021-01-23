        [DllImport("kernel32.dll")]
        public static extern int GetSystemDefaultLCID();
        private static int GetCmdCodePage()
        {
            int lcid = GetSystemDefaultLCID();
            var ci = System.Globalization.CultureInfo.GetCultureInfo(lcid);
            return ci.TextInfo.OEMCodePage;
        }

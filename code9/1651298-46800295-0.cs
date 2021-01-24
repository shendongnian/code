    public class IniSettings
    {
		private string _filename;
        public IniSettings(string filename)
        {
            _filename = filename;
        }
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key,
            string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key,
            string def, StringBuilder retVal, int size, string filePath);
        public string this[string section, string key]
        {
            get
            {
                StringBuilder sb = new StringBuilder(1024);
                GetPrivateProfileString(section, key, String.Empty, sb, 1024, _filename);
                return sb.ToString();
            }
            set
            {
                WritePrivateProfileString(section, key, value, _filename);
            }
        }
    }

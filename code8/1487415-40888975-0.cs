        public static string LocalUserAppDataPath
        {
            get
            {
                return GetDataPath(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            }
        }
        private static string GetDataPath(string basePath)
        {
            string format = @"{0}\{1}\{2}\{3}";
            string companyName = "YOUR_COMPANYNAME";
            string productName = "PRODUCTNAME";
            string productVersion = "PRODUCTVERSION";
            object[] args = new object[] { basePath, companyName, productName, productVersion };
            string path = string.Format(CultureInfo.CurrentCulture, format, args);
            return path;
        }

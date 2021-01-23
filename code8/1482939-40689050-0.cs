                    ChromeOptions options = new ChromeOptions();
                    option.AddUserProfilePreference("disable-popup-blocking", "true");
                    driver = new ChromeDriver(Path.Combine(GetBasePath, @"Drivers\\"), options);
                    
        public static string GetBasePath
        {
            get
            {
                var basePath =
                    System.IO.Path.GetDirectoryName((System.Reflection.Assembly.GetExecutingAssembly().Location));
                basePath = basePath.Substring(0, basePath.Length - 10);
                return basePath;
            }
        }

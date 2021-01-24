      public static IWebDriver RunIEAsDifferentUser(string User,string Password)
        {
            RunAs("C:\\Exlporer/IEDriverServer.exe", User, Password);
            _webdriverIE = new RemoteWebDriver(new Uri("http://localhost:5555/"), DesiredCapabilities.InternetExplorer(), TimeSpan.FromSeconds(180));
            return _webdriverIE;
            
        }
        public static void RunAs(string path, string username, string password)
        {
            ProcessStartInfo myProcess = new ProcessStartInfo(path);
            myProcess.UserName = username;
            myProcess.Password = MakeSecureString(password);
            myProcess.UseShellExecute = false;
            myProcess.LoadUserProfile = true;
            myProcess.Verb = "runas";
            myProcess.Domain = "DOM001";
            Process.Start(myProcess);
        }
        public static SecureString MakeSecureString(string text)
        {
            SecureString secure = new SecureString();
            foreach (char c in text)
            {
                secure.AppendChar(c);
            }
            return secure;
        }

    private List<Browser> GetBrowsers()
        {
            RegistryKey browserKeys;
            browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Clients\StartMenuInternet");
            if (browserKeys == null)
                browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");
            string[] browserNames = browserKeys.GetSubKeyNames();
            List<Browser> browsers = new List<Browser>();
            for (int i = 0; i < browserNames.Length; i++)
            {
                Browser browser = new Browser();
                RegistryKey browserKey = browserKeys.OpenSubKey(browserNames[i]);
                browser.Name = (string)browserKey.GetValue(null);
                RegistryKey browserKeyPath = browserKey.OpenSubKey(@"shell\open\command");
                browser.Path = browserKeyPath.GetValue(null).ToString().StripQuotes();
                browsers.Add(browser);
                if (browser.Path != null)
                    browser.Version = FileVersionInfo.GetVersionInfo(browser.Path).FileVersion;
                else
                    browser.Version = "unknown";
            }
            Browser edgeBrowser = GetEdgeVersion();
            if (edgeBrowser != null)
            {
                browsers.Add(edgeBrowser);
            }
            return browsers;
        }
        private Browser GetEdgeVersion()
        {
            RegistryKey edgeKey =
                Registry.CurrentUser.OpenSubKey(
                    @"SOFTWARE\Classes\Local Settings\Software\Microsoft\Windows\CurrentVersion\AppModel\SystemAppData\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\Schemas");
            if (edgeKey != null)
            {
                string version = edgeKey.GetValue("PackageFullName").ToString().StripQuotes();
                Match result = Regex.Match(version, "(((([0-9.])\\d)+){1})");
                if (result.Success)
                {
                    return new Browser
                    {
                        Name = "MicrosoftEdge",
                        Version = result.Value
                    };
                }
            }
            return null;
        }

        //Add this somewhere
        public System.Globalization.CultureInfo GetCurrentCultureInfo ()
        {
            var netLanguage = "en";
            if (NSLocale.PreferredLanguages.Length > 0) {
                var pref = NSLocale.PreferredLanguages [0];
                netLanguage = pref.Replace ("_", "-"); // turns en_US into en-US
            }
            try
            {
                return new System.Globalization.CultureInfo(netLanguage);
            }catch{
                try{
                    return new System.Globalization.CultureInfo(netLanguage.Substring(0, netLanguage.IndexOf("-")));
                }
                catch{
                    return new System.Globalization.CultureInfo("en");
                }
            }
        }
        //And finally add this at the start of the app
        AppResources.Culture = GetCurrentCultureInfo();

    private void SetLanguage(string cultureName)
        {
            var cul = new System.Globalization.CultureInfo(cultureName);
            Properties.Resources.Culture = cul;
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = cul;
            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = cul;
            System.Threading.Thread.CurrentThread.CurrentUICulture = cul;
            System.Threading.Thread.CurrentThread.CurrentCulture = cul;
            InitializeHamburgerMenu();
            MainWindowView.RegreshLanguage();
            RaisePropertyChanged("Title");
        }

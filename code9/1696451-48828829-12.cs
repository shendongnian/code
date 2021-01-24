    public abstract BaseViewModel
    {
        private ISettingsService _settings;
        protected ISettingsService GeneralSettings
        {
             get
             {
                 if (_settings == null)
                     _settings = Bootstrapper.Container.GetInstance<ISettingsService>();
                 return _settings;
             }
        }
    }
    

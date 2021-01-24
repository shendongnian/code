    public class CustomConfigurationProvider : ConfigurationProvider
    {
        private readonly string applicationName;
        private readonly bool reloadOnChange;
        private readonly IConfiguration configuration;
        public CustomConfigurationProvider(string applicationName, bool reloadOnChange)
        {
            this.applicationName = applicationName;
            this.reloadOnChange = reloadOnChange;
			if(reloadOnChange)
			{
            ChangeToken.OnChange(
                () => GetReloadToken(), // listener to token change
                () =>
                {
                    Thread.Sleep(250);
                    this.Load();
                });
			}
        }
        public override async void Load()
        {
            Data.Clear();
            Data = read data from database;
            if (Condition to check if data in database changed)
            {
                OnReload(); // This will create new token and trigger change so what is register in OnChange above will be called again which is this.Load()
            }
        }
    }

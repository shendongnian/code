    public class SettingProvider<TSetting> : ISettingProvider<TSetting>
        where TSetting : ISetting, new()
    {
        private readonly ISettingService service;
        public SettingProvider(ISettingService service) {
            this.service = service;
        }
        public TSetting Value => this.service.GetSetting(new TSetting());
    }

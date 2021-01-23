    public interface ISettingProvider<TSetting> where TSetting : ISetting
    {
        TSetting Value { get; }
    }
    public class SettingProvider<TSetting> : ISettingProvider<TSetting> where TSetting : ISetting, new()
    {
        private readonly ISettingService service;
        public SettingProvider(ISettingService service)
        {
            this.service = service;
        }
        public TSetting Value => this.service.LoadSetting<TSetting>();
    }

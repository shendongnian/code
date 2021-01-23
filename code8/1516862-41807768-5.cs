    public interface ISettingService : IService<Setting>
    {
        T LoadSetting<T>() where T : ISetting, new();
        ISetting LoadSettingOLD(object setting);
        void SetSetting(ISetting setting);
    }
    public class SettingService : Service<Setting>, ISettingService {
        private readonly IRepositoryAsync<Setting> _repository;
        public SettingService(IRepositoryAsync<Setting> repository) : base(repository) {
            _repository = repository;
        }
        public T LoadSetting<T>() where T : ISetting, new() {
            var setting = Activator.CreateInstance<T>();
            var settingName = setting.GetType().Name;
            var properties = setting.GetType().GetProperties();
            var ayars = GetAllSettingsCached()
                .Where(x => x.Name.StartsWith(settingName)).ToList();
            foreach (var propertyInfo in properties)
            {
                var settingPropertyName = settingName + "." + propertyInfo.Name;
                var q = ayars.FirstOrDefault(x => x.Name == settingPropertyName);
                if (q != null)
                {
                    propertyInfo.SetValue(setting, 
                        Convert.ChangeType(q.Value, propertyInfo.PropertyType), null);
                }
            }
            return setting;
        }
    }

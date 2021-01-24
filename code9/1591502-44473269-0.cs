    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class XNameDisplayFormatAttribute : DisplayFormatAttribute
    {
        public static DisplayFormatManager FormatsManager { get; set; }
    
        public XNameDisplayFormatAttribute(bool applyFormatInEditMode = true)
        {
            DataFormatString = FormatsManager.GetDataFromDb(_dataFormatString);
            ApplyFormatInEditMode = applyFormatInEditMode;
        }
    
        private string _dataFormatString;
        public new string DataFormatString
        {
            get => FormatsManager.GetDataFromDb(_dataFormatString);
            set => _dataFormatString = value;
        }
    }
    
    public class DisplayFormatManager
    {
        public DisplayFormatManager(Func<ISettingsService> settingsServiceFactory)
        {
            SettingsServiceFactory = settingsServiceFactory;
        }
    
        public Func<ISettingsService> SettingsServiceFactory { get; }
    
        public string GetDataFromDb(string format)
        {
            var service = SettingsServiceFactory();
            return service.GetDataFromDb(format);
        }
    }
    
    public interface ISettingsService
    {
        string GetDataFromDb(string format);
    }

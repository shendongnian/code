    public class ConfigurationWindowViewModel : BindableBase
    {
       public ConfigurationWindowViewModel()
       {
        ConfigDetails = new ObservableCollection<ConfigurationDetails>();
        //add some items...:
        ConfigDetails.Add(new ConfigurationDetails() { ConfigFName = "F", ConfigSName = "S", ConfigUName = "U" });
        ConfigDetails.Add(new ConfigurationDetails() { ConfigFName = "F", ConfigSName = "S", ConfigUName = "U" });
        ConfigDetails.Add(new ConfigurationDetails() { ConfigFName = "F", ConfigSName = "S", ConfigUName = "U" });
       }
       private ObservableCollection<ConfigurationDetails> _configDetails;
       public ObservableCollection<ConfigurationDetails> ConfigDetails { get { return _configDetails; } set { SetProperty(ref _configDetails, value); } }
    }

    public class SettingsViewModel : ViewModelBase
    {
    	SettingProvider objSettingProvider = new SettingProvider();
    	
        public double Volumne 
        {
            get
            {
                return objSettingProvider.Volumne;
            }
            set
            {
                objSettingProvider.Volumne = value;
    			OnPropertyChanged("Volumne");
            }
        }
    	
    	// Implementaion of other properties of SettingProvider with your ViewModel properties;
    	
    	
    	private ICommand saveSettingButtonCommand;
        public ICommand SaveSettingButtonCommand
        {
            get
            {
                return saveSettingButtonCommand ?? (saveSettingButtonCommand = new CommandHandler(param => saveSettings(param), true));
            }
        }
    
    	private void saveSettings()
    	{
    		objSettingProvider.SaveSettings();
    	}
    }

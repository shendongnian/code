    class SettingsForm
    {
    
       public static event ColourSettingChangedDelegate ColourSettingsChangedEvent;
       public delegate void ColourSettingChangedDelegate(Color color);
    
       public void SaveSettings()
       {
          //Update colour setting
          OnColourSettingsChanged(color);
       }
    
       private void OnColourSettingsChanged(Color color)
       {
          if (ColourSettingsChangedEvent!=null)
            ColourSettingsChangedEvent(color);
       }
    }

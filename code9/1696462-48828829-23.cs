    public class SettingsServiceFromApplication : ISettingsService
    {
        public double Volume 
        {
            get 
            {
               return Properties.Settings.Volume;
            }
        }
        [...]
    }

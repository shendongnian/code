    public class SettingsServiceFromDb : ISettingsService
    {
        public double Volume 
        {
            get 
            {
               return MyDb.Volumen;
            }
        }
        [...]
    }

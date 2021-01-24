    public abstract class ComPortSettingsBase
    {
    }
    public class ComportSettings : ComPortSettingsBase
    {
    }
    public abstract class Comport
    {
        private ComPortSettingsBase settings;
        public ComPortSettingsBase Settings
        {
             
            get
            {
                return this.settings;
            }
            set
            {
                this.settings = value;
            }
        }
    }
    public class ComportSetup : Comport
    {
        private ComPortSettingsBase Settings;
        public ComportSettings Settings
        {
            get
        {
            return (ComportSettings)base.Settings;
        }
            set
            {
                // The problem is here.
                // Firts of all type casting is not valid. It causes type casting exception
                // If I remove the type casting it causes stackoverflow exception normally. 
                base.Settings = (ComPortSettingsBase)value;
            }
        }
    }

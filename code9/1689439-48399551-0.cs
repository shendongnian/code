    public abstract class ComportSettingsBase
    {
    }
    public class ComportSettings : ComportSettingsBase
    {
    }
    public abstract class Comport
    {
        private ComportSettingsBase settings;
        public ComportSettingsBase Settings
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
        public ComportSettings Settings
        {
            get
            {
                return (ComportSettingsBase)base.Settings
            }
            set
            {
                // The problem is here.
                // Firts of all type casting is not valid. It causes type casting exception
                // If I remove the type casting it causes stackoverflow exception normally. 
                this.Settings = (ComPortSettingsBase)value;
            }
        }
    }

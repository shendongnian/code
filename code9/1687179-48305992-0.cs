    public abstract class PluginBase
    {
        // move it to the generic base class
        // protected SettingBase LocalSettings { get; set; }
    }
    public abstract class PluginBase<TSettings> : PluginBase where TSettings : SettingBase
    {
        protected TSettings LocalSettings { get; set; }
    }
    public abstract class SettingBase
    {
    }
    public class MyPlugin : PluginBase<MySettings>
    {
        public void DoIt()
        {
            Console.WriteLine(this.LocalSettings.MyValue);
        }
    }
    public class MySettings : SettingBase
    {
        public string MyValue;
    }

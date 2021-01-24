    public class MyThingDoer
    {
        public MyThingDoer(IConfigurationWrapper config)
        {
             _config = config
        }
        public string SaySomething()
        {
            var thingToSay = _config.GetAppSetting("ThingToSay");
            return thingToSay;
        }
    }

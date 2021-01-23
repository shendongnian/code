    [Serializable]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Interface, AllowMultiple = true)]
    public class ConfiguredLuisModelAttribute : LuisModelAttribute, ILuisModel
    {
        public ConfiguredLuisModelAttribute() : base(
            GetModelId(), 
            GetSubscriptionKey(), 
            LuisApiVersion.V2,
            staging: GetStaging()) { }
        private static string GetModelId()
        {
            return ConfigurationManager.AppSettings.Get("LuisModelId");
        }
        private static string GetSubscriptionKey()
        {
            return ConfigurationManager.AppSettings.Get("LuisSubscriptionKey");
        }
        private static bool GetStaging()
        {            
            return Convert.ToBoolean(ConfigurationManager.AppSettings.Get("LuisStaging") ?? bool.FalseString);
        }

    namespace ChatBot_LUIS.Dialogs
    {
    	[Serializable]
    	public class BaseLuisDialog<T> : LuisDialog<T>
    	{
    		public BaseLuisDialog() : base(GetNewService())
    		{
    			
    		}
    
    		private static ILuisService[] GetNewService()
    		{
    			var modelId = ConfigurationManager.AppSettings.Get("LuisModelId");
    			var subscriptionKey = ConfigurationManager.AppSettings.Get("LuisSubscriptionKey");
    			var staging = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("LuisStaging") ?? "false");
    			var luisModel = new LuisModelAttribute(modelId, subscriptionKey, staging: staging);
    			return new ILuisService[] { new LuisService(luisModel) };
    		}
    	}
    }

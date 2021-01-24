    using Jint;
    using Newtonsoft.Json;
    
    namespace Extensions
    {
    	public static class EngineExtentions {
    		public static void SetJsonValue(this Engine source, string name, object value)
    		{
    			source.SetValue(name, JsonConvert.SerializeObject(value));
    			source.Execute($"{name} = JSON.parse({name})");
    		}
    	}
    }

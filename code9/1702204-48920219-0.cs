    public interface IConfigurationProvider
    {
    	string GetValue(string key, string valueIfNull = "");
    }
    
    using System.Configuration;
    public class ConfigurationProvider : IConfigurationProvider
    {
    	public string GetValue(string key, string valueIfNull = "")
    	{
    		return (!String.IsNullOrEmpty(ConfigurationManager.AppSettings[key]) 
    			? ConfigurationManager.AppSettings[key] 
    			: valueIfNull);
    	}
    }

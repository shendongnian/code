    public interface IConfigReader
    {
    	string ReadConfigEntry(string keyName);
    }
    
    public class ConfigReader : IConfigReader
    {
    	public string ReadConfigEntry(string keyName)
    	{
    		return System.Configuration.ConfigurationManager.AppSettings[keyName];
    	}
    }
    
    public class FakeConfigReader : IConfigReader
    {
    	public string ReadConfigEntry(string keyName)
    	{
    		string configValue = string.Empty;
    
    		//provide dummy implementation instead of reading actual .config file
    
    		return configValue;
    	}
    }

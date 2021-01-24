	void Main()
	{
		var settings = new Settings();
	
		// no key {}
		settings.OptionalIntegerSetting = null;
		JsonConvert.SerializeObject(settings).Dump();
	
		// null key {\"OptionalIntegerSetting\" : null}
		settings.OptionalIntegerSetting = null;
		settings.OptionalIntegerSettingSpecified = true;
		JsonConvert.SerializeObject(settings).Dump();
	
		// has value {\"OptionalIntegerSetting\" : 123}
		settings.OptionalIntegerSetting = 123;
		JsonConvert.SerializeObject(settings).Dump();
	
		JsonConvert.DeserializeObject<Settings>("{}").Dump();
		JsonConvert.DeserializeObject<Settings>("{'OptionalIntegerSetting' : null}").Dump();
		JsonConvert.DeserializeObject<Settings>("{'OptionalIntegerSetting' : '123'}").Dump();
	}
	
	public class Settings
	{
		public uint? OptionalIntegerSetting { get; set; }
		[JsonIgnore]
		public bool OptionalIntegerSettingSpecified { get; set;}
	}

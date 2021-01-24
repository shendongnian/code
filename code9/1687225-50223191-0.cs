    class LocalSettings
    {
        public bool IsEncrypted { get; set; }
        public Dictionary<string, string> Values { get; set; }
    }
    public static void SetupEnvironment()
	{
		string basePath = Path.GetFullPath(@"..\..\..\MyAzureFunc");
		var settings = JsonConvert.DeserializeObject<LocalSettings>(
			File.ReadAllText(basePath + "\\local.settings.json"));
		foreach (var setting in settings.Values)
		{
			Environment.SetEnvironmentVariable(setting.Key, setting.Value);
		}
	}

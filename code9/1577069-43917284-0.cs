    class Configuration {
    	Dictionary<string, List<Dictionary<string, string>>> ParsedConfig = new Dictionary<string, List<Dictionary<string, string>>>();
    
    	public Configuration(string fileName) {
    		ParseConfig(File.ReadLines(fileName));
    	}
    
    	void ParseConfig(IEnumerable<string> lines) {
    		foreach (string line in lines) {
    			string[] splitLine = line.Split(new char[] { '=' }, 2);
    			if (splitLine.Length != 2)
    				continue;
    
    			var cfgKey = splitLine[0].Trim();       // you probably want to get rid of trailing and leading spaces
    			var cfgValue = splitLine[1].Trim();
    
    			if (!cfgKey.Contains('.')) { // handle regular keys
    				var singularList = new List<Dictionary<string, string>>();
    				ParsedConfig[cfgKey] = singularList;
    				singularList.Add(new Dictionary<string, string>());
    				singularList[0][string.Empty] = cfgValue;
    				continue;
    			}
    
    
    			var keyParts = cfgKey.Split(new char[] { '.' }, 3); // break down the dotted key
    			if (keyParts.Length != 3)
    				continue;
    
    
    			if (!ParsedConfig.TryGetValue(keyParts[0], out var indexedConfigList))
    				ParsedConfig[keyParts[0]] = indexedConfigList = new List<Dictionary<string, string>>();
    
    			var index = int.Parse(keyParts[1]);
    
    			while (indexedConfigList.Count <= index) // add array slots for all indexes
    				indexedConfigList.Add(null);
    
    			var indexedConfig = indexedConfigList[index];
    			if (indexedConfig == null)
    				indexedConfigList[index] = indexedConfig = new Dictionary<string, string>();
    
    			indexedConfig[keyParts[2]] = cfgValue;
    		}
    
    	}
    
    	public Dictionary<string, string> GetGroupedConfig(string key, int index) {
    		if (ParsedConfig.TryGetValue(key, out var indexedConfigList) && indexedConfigList.Count > index)
    			return indexedConfigList[index];
    
    		return null;
    	}
    
    	public string GetConfigValue(string key) {
    		string value = null;
    		if (ParsedConfig.TryGetValue(key, out var indexedConfigList) && indexedConfigList.Count > 0)
    			indexedConfigList[0].TryGetValue(string.Empty, out value);
    		return value;
    	}
    
    }

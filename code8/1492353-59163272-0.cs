    public static void SetAppSettingValue(string key, string value, string appSettingsJsonFilePath = null) {
     if (appSettingsJsonFilePath == null) {
      appSettingsJsonFilePath = System.IO.Path.Combine(System.AppContext.BaseDirectory, "appsettings.json");
     }
    
     var json = System.IO.File.ReadAllText(appSettingsJsonFilePath);
     dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject < Newtonsoft.Json.Linq.JObject > (json);
    
     jsonObj[key] = value;
    
     string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
    
     System.IO.File.WriteAllText(appSettingsJsonFilePath, output);
    }

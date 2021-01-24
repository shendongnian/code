     Dictionary<string, string> dict = new Dictionary<string, string>();
     dict.Add("User.Info", "Your info");
     dict.Add("User.Profile", "Profile");
     dict.Add("Menu.System.Task", "Tasks");
     dict.Add("Menu.System.Configuration.Number", "1");
     dict.Add("Menu.System.Configuration.Letter", "A");
     var outputDic = new Dictionary<string, object>();
     foreach (var kvp in dict)
     {
         var keys = kvp.Key.Split('.');
         SetValues(keys, kvp.Value, outputDic);
      }
      var json = JsonConvert.SerializeObject(outputDic);

     Dictionary<string, string> dict = new Dictionary<string, string>();
        dict.Add("User.Info", "Your info");
        dict.Add("User.Profile", "Profile");
        dict.Add("Menu.System.Task", "Tasks");
        JsonSerializerSettings obj = new JsonSerializerSettings();
        obj.Converters.Add(new CustomJsonConverter());
        var output1 = JsonConvert.SerializeObject(dict,obj);

    public class Foo
    {
        private Dictionary<int, Dictionary<string, string>> settings;
        private int UserId;
        public void LoadDefaultSettings()
        {
            if (!settings.ContainsKey(0))
            {
                settings.Add(0, new Dictionary<string, string>());
            }
            settings[0] = GetDefaultSettings();
        }
        public string Get(string key)
        {
            if (settings.ContainsKey(UserId) && settings[UserId].ContainsKey(key))
            {
                return settings[UserId][key];
            }
            return settings[0].ContainsKey(key) ? settings[0][key] : string.Empty;
        }
        public void Set(string key, string value)
        {
            if (!settings.ContainsKey(UserId))
            {
                settings.Add(UserId, new Dictionary<string, string>());
            }
            settings[UserId][key] = value;
        }
    }

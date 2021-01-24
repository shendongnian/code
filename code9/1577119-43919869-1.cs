    public class Foo
    {
        private Dictionary<int, Dictionary<string, string>> settings;
        /// <summary>
        /// Populates settings[0] with the default settings for the application
        /// </summary>
        public void LoadDefaultSettings()
        {
            if (!settings.ContainsKey(0))
            {
                settings.Add(0, new Dictionary<string, string>());
            }
            // Some magic that returns a dictionary of default settings
            settings[0] = GetDefaultSettings(); 
        }
        /// <summary>
        /// Adds a user-defined key or overrides a default key value with a User-specified value
        /// </summary>
        /// <param name="key">The key to add or override</param>
        /// <param name="value">The key's value</param>
        public void Set(string key, string value, int userId)
        {
            if (!settings.ContainsKey(userId))
            {
                settings.Add(userId, new Dictionary<string, string>());
            }
            settings[userId][key] = value;
        }
        /// <summary>
        /// Gets the User-defined value for the specified key if it exists, 
        /// otherwise the default value is returned.
        /// </summary>
        /// <param name="key">The key to search for</param>
        /// <returns>The value of specified key, or empty string if it doens't exist</returns>
        public string Get(string key, int userId)
        {
            if (settings.ContainsKey(userId) && settings[userId].ContainsKey(key))
            {
                return settings[userId][key];
            }
            return settings[0].ContainsKey(key) ? settings[0][key] : string.Empty;
        }        
    }

        public void Set<T>(string key, T value)
        {
            string serialized = JsonConvert.SerializeObject(value);
            var settings = ApplicationData.Current.LocalSettings.Values;
            if (!settings.Keys.Contains(key))
            {
                settings.Add(key, serialized);
            }
            else
            {
                settings[key] = serialized;
            }
        }
        private bool TryGet<T>(string key, out T result)
        {
            var settings = ApplicationData.Current.LocalSettings.Values;
            if (!settings.Keys.Contains(key))
            {
                result = default(T);
                return false;
            }
            var value = settings[key] as string;
            try
            {
                result = JsonConvert.DeserializeObject(value, typeof(T));
                return true;
            }
            catch
            {
                result = default(T);
                return false;
            }
        }

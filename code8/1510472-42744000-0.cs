    public class SettingsViewModel : BindableBase
    {
        public string MyProperty
        {
            get
            {
                return Get("MyProperty", "SomeDefaultValue");
            }
            set
            {
                Set("MyProperty", value);
            }
        }
        public T Get<T>(string PropertyName, T DefaultValue)
        {
            //If setting doesn't exist, create it.
            if (!App.Settings.ContainsKey(PropertyName))
                App.Settings[PropertyName] = DefaultValue;
            return (T)App.Settings[PropertyName];
        }
        public void Set<T>(string PropertyName, T Value)
        {
            //If setting doesn't exist or the value is different, create the setting or set new value, respectively.
            if (!App.Settings.ContainsKey(PropertyName) || !((T)App.Settings[PropertyName]).Equals(Value))
            {
                App.Settings[PropertyName] = Value;
                OnPropertyChanged(PropertyName);
            }
        }
    }

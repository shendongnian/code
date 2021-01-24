    public class StorePreference : Preference { }
    public class UserPreference : Preference { }
    public class Preference {
        public Preference() {
            BackgroundColor = DefaultPreference.BackgroundColor;
            ContactMethod = DefaultPreference.ContactMethod;
        }
        public string BackgroundColor { get; set; }
        public ContactMethod ContactMethod { get; set; }
        public DefaultPreference DefaultPreference { get; set; }
    }
    public class DefaultPreference {
        public string BackgroundColor { get; set; }
        public ContactMethod ContactMethod { get; set; }
    }

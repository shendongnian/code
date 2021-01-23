    public class SettingsTestHelper:ISetting
    {
        private _valueToReturn;
        public SettingsTestHelper(string valueToReturn)
        {
            _valueToReturn=valueToReturn;
        }
        public string GetConfigItem(string itemName)
        {
            return valueToReturn;
        }
    }

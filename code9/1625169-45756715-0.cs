    public class SomePlugin
    {
        private DataObject _data;
        private bool _dataIsDirty = false;
    
        public bool IsDirty => _dataIsDirty || (_data?.IsDirty ?? false);
    
        private class DataObject
        {
            private bool _dataIsDirty = false;
    
            public bool IsDirty => _dataIsDirty || (Settings?.IsDirty ?? false);
            public GeneralSettings Settings { get; set; }
        }
    
        private class GeneralSettings
        {
            public bool IsDirty { get; set; }
    
            private string _settingOne;
    
            public string SettingOne
            {
                get { return _settingOne; }
                set
                {
                    if (value != _settingOne)
                    {
                        IsDirty = true;
                        _settingOne = value;
                    }
                }
            }
    
            public string SettingTwo { get; set; } // Won't mark as dirty
        }
    }

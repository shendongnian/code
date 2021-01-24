    class ObjValidator2: IObjValidator
    {
        private readonly ISettingsFactory settingsFactory;
    
        public ObjValidator2(ISettingsFactory settingsFactory)
        {
            this.settingsFactory = settingsFactory;
        }
    
        public bool Validate()
        {
            ISettings settings = settingsFactory.CreateSettings(fileName);   
        }
    }

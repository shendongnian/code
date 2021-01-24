    class ObjValidatorFactory: IObjValidatorFactory
    {
        private ISettingsFactory settingsFactory;
    
        public ObjValidatorFactory(ISettingsFactory settingsFactory)
        {
            this.settingsFactory = settingsFactory;
        }
        
        IObjValidator Create(ObjValidatorMode mode)
        {
            //source could be the file name for example
            ISettings settings = settingsFactory.Create(source);
            switch(mode)
            {
                 case ObjValidatorMode.One:
                     return ObjValidator1();
    
                 case ObjValidatorMode.Two:
                     return ObjValidator2(settings);
            }
        }
        
    }

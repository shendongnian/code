    public class test : MonoBehaviour {
    
        public GraphicSettings CurrentGraphicsSetting;
        public GraphicSettings LowGraphicsSetting = new GraphicSettings() { pThing1 = 23, pThing2 = "test23" };
        public GraphicSettings HighGraphicsSetting = new GraphicSettings() { pThing1 = 2300, pThing2 = "test23sd" };
    
        public class GraphicSettings
        {
            public int pThing1 = 0;
            public string pThing2 = "test";
        }
    
        private void UpdateCurrentGraphicSettingValue(Dropdown pDropdown)
        {
            if (pDropdown.value == 0)
            {
                CurrentGraphicsSetting = LowGraphicsSetting;
            }
            else
            {
                CurrentGraphicsSetting = HighGraphicsSetting;
            }
    
            ApplyGraphicSettings();
        }
    
        private void ApplyGraphicSettings()
        {
            SomeSetting = CurrentGraphicsSetting.pThing1;
            SomeOtherSetting = CurrentGraphicsSetting.pThing2;
        }
    }

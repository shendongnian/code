    public class utilSvc : IUtilScv {
        private readonly IConfigHelper configUtil;
    
        public utilSvc(IConfigHelper configHelper) {
            configUtil = configHelper;
        }
        
        public string GetConfigurationValue() {
            return configUtil.GetConfiguration("sectionName/sectionElement", "ClinicalSystem");
        }
    }

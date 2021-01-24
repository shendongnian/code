    public class utilSvcWrapper : IUtilSvc {
        public string GetConfigurationValue() {
            return utilSvc.GetConfigurationValue(); //Calling static service
        }
    }

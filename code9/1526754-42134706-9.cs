    public class myRealClass {
        private readonly IUtilScv utilSvc;
        //Explicit dependency inject via constructor
        public myRealClass(IUtilScv utilSvc) {
            this.utilSvc = utilSvc;
        }
    
        public string myworkingMethod() {
            var retValue = utilSvc.GetConfiguration();
            return retValue;
        }
    }

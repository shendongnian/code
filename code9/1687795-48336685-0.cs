    public class get
    {
        private CrmServiceClient crmSvc = null;
        private IOrganizationService crmService = null;
    
        public get()
        {
    		// New line to force TLS 1.2
    		System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
    
            this.crmSvc = new CrmServiceClient(ConfigurationManager.ConnectionStrings["CRM"].ConnectionString);
            this.crmService = this.crmSvc.OrganizationServiceProxy;
        }
    }

        public ActionResult Index()
        {
           getResultAsync().Wait();
            return View();
        }
        public static async Task getResultAsync()
        {
            string subscription = "subid";
            string tenantid = "tenantid ";
            string clientId = "clientId ";
            string key = "key";
 
            var serviceCreds = await ApplicationTokenProvider.LoginSilentAsync(tenantDomain, clientId, key);
            BillingManagementClient b1 = new BillingManagementClient(serviceCreds) { SubscriptionId = subscription };
            var result = b1.Operations.List();
        }

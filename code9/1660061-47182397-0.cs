    public class UserAccountController : Controller
    {
        private readonly IRServiceClient rServiceClient;
    
        // class does not have hidden dependencies
        public UserAccountController (IRServiceClient rServiceClient)
        {
            this.rServiceClient = rServiceClient;
        }
    
        public ActionResult GetVerifyLogin()
        {
            //...
            foreach (var siteItem in siteResult.ResultSet)
            {
                 result.SiteNum = siteItem.SiteNum;
                 result.DevNum = siteItem.DevNum;
                 result.TrasmitterCode = siteItem.TransmitterCode;
            }
            var xipResult = rServiceClient.ZipCodeVerifyForXmit(result.TrasmitterCode);
            result.ZipCodeVerify = xipResult.ZipCodeVerifyDealer;
            result.ZipCode = xipResult.ZipCode;  
            //...          
        }
    }

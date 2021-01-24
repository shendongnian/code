        public class HomeController : Controller
    {
        public ActionResult GetAccountStatus()
        {
            var client = new WebClient();
            client.Encoding = Encoding.UTF8;
            var response = client.DownloadString("https://payments-uk-sandbox.amazon.com/merchantAccount/AAAJJFJJJFJJF/accountStatus?countryOfEstablishment=UK&ledgerCurrency=GBP");
            return response;
        }
    }

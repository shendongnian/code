    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        //Add test record
        public ActionResult About()
        {
            ApplicationDbContext d1 = new ApplicationDbContext();          
            ApplicationUser user = d1.Users.FirstOrDefault(w => w.UserName.Equals("UserName"));
            Wallet w1 = new Wallet();
            w1.ApplicationUser = user;
            w1.Founds = 300;
            UserStock u1 = new UserStock();
            u1.id = 1;
            List<UserStock> l1 = new List<UserStock>();
            l1.Add(u1);
            w1.WalletId = user.Id;
            d1.Wallets.Add(w1);
            d1.SaveChanges();
            ViewBag.Message = "Add Completed";
            return View();
        }
        
        //Call the Repository to get the value
        public ActionResult Contact()
        {
            WalletRepository walletRepository = new WalletRepository();
            var result = walletRepository.GetMarketWallet();
            ViewBag.Message = "WalletId : " + result.WalletId;
            return View();
        }
    }

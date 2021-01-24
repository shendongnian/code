    public class WalletRepository
    {
        public ApplicationDbContext context;
        public WalletRepository() { context = ApplicationDbContext.Create(); }
        public Wallet GetMarketWallet()
        {
            string stockMarketUserName = "The user name";
            return context.Wallets.FirstOrDefault(w => w.ApplicationUser.UserName.Equals(stockMarketUserName));
        }
    }

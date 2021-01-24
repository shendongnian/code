    public class Wallet
    {
        [Key, ForeignKey("ApplicationUser")]
        public string WalletId { get; set; }
        public decimal Founds { get; set; }
        public virtual IList<UserStock> OwnedStocks { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public Wallet()
        {
            OwnedStocks = new List<UserStock>();
        }     
    }

    public class Customer : BaseEntity
    {
        public Customer(Name name, DateTime? birthDay, Email email, string password, List<CreditDebitCard>  creditDebitCards = null)
        {
            CreationDate = DateTime.Now;
            Name = name;
            BirthDay = birthDay;
            Email = email;
            Password = password;
            _CreditDebitCards = creditDebitCards ?? new List<CreditDebitCard>();
        }
        #region Fields
        private IList<CreditDebitCard> _CreditDebitCards;
        #endregion
        #region Properties
        public  Name Name { get; private set; }
        public DateTime? BirthDay { get; private set; }
        public  Email Email { get; private set; }
        public string Password { get; private set; }
        public int? CreditDebitCardId { get; private set; }
        public ICollection<CreditDebitCard> CreditDebitCards => _CreditDebitCards;
        public IEnumerable<Order> Orders { get; private set; }
        public Seller Seller { get; private set; }
        public int SellerId { get; private set; }
        #endregion

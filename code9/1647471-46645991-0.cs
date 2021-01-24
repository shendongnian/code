    public class AccountType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AccountCode> AccountCodes
        { 
            get { /* Load child data here */ }
            set { /* ... */ }
        }
    }

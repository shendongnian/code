    public class Account
    {
        public Account()
        {
            this.Transactions = new HashSet<Transaction>();
        }
    
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        [Range(double.MinValue, double.MaxValue)]
        public decimal Balance { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Range(double.MinValue, double.MaxValue)]
        public decimal ReconciledBalance
        {
            get 
            { 
                 return Transactions.Where(t => t.IsActive == true && t.IsReconciled == true).Sum(x => x.Amount) 
            }
            private set { /* needed for EF */ }
        }
    
        //FKs
        public int HouseholdId { get; set; }
    
        //Virtual Properties
        public virtual Household Household { get; set; }// One to one
        public virtual ICollection<Transaction> Transactions { get; set; }
    }

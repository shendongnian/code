    public class Bank
    {
        public int Id;
        public string Name;
    }
    public class BankBranch
    {
       public int Id;
       public string BranchName;
       public int BankId { get; set; }
       [ForeignKey("BankId")]
       public virtual Bank Bank { get; set; }
    }

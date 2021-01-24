    public class Company
    {
       public int Id;
       public int BankBranchId { get; set; }
       [ForeignKey("BankBranchId")]
       public virtual BankBranch BankBranch { get; set; }
    }

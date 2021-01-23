    public interface IAccountHBSearchItem
    {
    	long AccountTransactionID { get; set; }
    	long LeadID { get; set; }
    	string Address { get; set; }
    	string LotNumber { get; set; }
    	string Type { get; set; }
    	bool Debit { get; set; }
    	bool Credit { get; set; }
    	decimal RemainingBalance { get; set; }
    	DateTime TransDate { get; set; }
    }

    [Given(@"these receipts:")]
    public void GivenTheseReceipts(Table table)
    {
    	var receipts = table.CreateSet<Receipt>(); // you can even create a set given you have defined the Receipt class
    }
    public class Receipt
    {
    	public decimal Amount { get; set; }
    	public DateTime Date { get; set; }
    	public string Company { get; set; }
    }

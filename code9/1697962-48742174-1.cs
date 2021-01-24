    public class InvoiceLine
    {
    	public Guid Id { get; set; }
    	public int LineNumber { get; set; }    
    	public List<InvoiceLineProductCode> ProductCodes { get; set; } // <--
    }

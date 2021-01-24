    public class InvoiceLineProductCode
    {
    	public Guid InvoiceLineId { get; set; }
    	public InvoiceLine InvoiceLine { get; set; }
    	public string ProductCodeCategory { get; set; } // <--
    	public string ProductCodeValue { get; set; } // <--
    	public ProductCode ProductCode { get; set; }
    }

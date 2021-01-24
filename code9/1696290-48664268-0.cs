    public class DropDownViewModel
    {
    	[Display(Name = "Dealer")]
    	public int? DealerIdRef { get; set; }
    
    	public IEnumerable<SelectListItem> Ddllist { get; set; }
    }

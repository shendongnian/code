    public class AppHelpersViewModel : ViewModelBase
    {
    	public AppHelpersViewModel()
    	{
    		ViewRole = ViewRole.Edit;
    	}
    
    	[Display(Name = "Text Display Name", Prompt = "Text Display Prompt")]
    	public string TextInput { get; set; }
    
    	[Display(Name = "Number Display Name")]
    	public decimal NumberInput { get; set; }
    
    	[Display(Name = "Date Display Name")]
    	public DateTime? DateInput { get; set; }
    
    	[Display(Name = "Bool Display Name", Prompt ="Bool Display Prompt")]
    	public bool BoolInput { get; set; }
    
    	[Display(Name = "Required Text Input Label", Prompt = "Placeholder Text")]
    	[Required]
    	public string RequiredTextInput { get; set; }
    
    
    	public AppHelpersViewModel GetDisplayCopy()
    	{
    		var displayCopy = this.MemberwiseClone() as AppHelpersViewModel;
    
    		displayCopy.ViewRole = ViewRole.Display;
    
    		displayCopy.TextInput = "TextInput content";
    		displayCopy.RequiredTextInput = "RequiredTextInput content";
    		displayCopy.NumberInput = 45.4m;
    		displayCopy.DateInput = new DateTime(2016, 10, 24);
    		displayCopy.BoolInput = true;
    
    		return displayCopy;
    	}
    }

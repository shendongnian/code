    public class CustomModel : PageModel
    {
	   public IMyService _myService;
	   
	   public CustomModel(IMyService myService)
       {
		   _myService = myService;
       }
	   
	   public async Task<IActionResult> OnPostAsync(...)
       {
			...
			
			_myService.SetDataOrSometing(...);
			
			...
			
			return RedirectToPage();
	   }
	}

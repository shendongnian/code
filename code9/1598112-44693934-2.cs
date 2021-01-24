    public class YourModel
    {
       
       [Required(ErrorMessage = "Price is required")]
       [Display(Name = "Retail")]
       [Range(0, double.MaxValue)]
       public double Price { get; set; }
       
    }
    
    
    [HttpGet]
    public ActionResult Index()
    {
    	return View(new YourModel());
    }
    [HttpPost]
    public ActionResult Index( YourModel model)
    {				
    	if(ModelState.IsValid)
    	{
    		//model is valid, add your code here 
    	}
    	else
    	{
            //returns with model validation error
    		return View();
    	}
    			
    }

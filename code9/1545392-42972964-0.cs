    public class TestController:Controller
    {
        public ActionResult Action1(MyModel data)
    	{
    		try
    		{
    			if (!ModelState.IsValid)
    			{
    				var errors = ModelState.Values.Where(c => c.Errors.Count > 0).SelectMany(c => c.Errors.Select(o => o.ErrorMessage));
    				var errorMsg = String.Join("<br/>", errors);
    				return Json(new
    				{
    					IsSuccess = false,
    					Message = errorMsg
    				});
    			}
    			//deal business
    			return Json(new { IsSuccess = true, Message = "success" });
    		}
    		catch (Exception ex)
    		{
    			return Json(new { IsSuccess = false, Message = "fail" });
    		}
    	}
    }
    public class MyModel : IValidatableObject
    {
    	[Required(ErrorMessage = "{0} is required")]
    	public decimal TotalPrice { get; set; }
    	[Required(ErrorMessage = "{0} is required")]
    	public decimal TotalPriceWithoutCoupon { get; set; }
    	public ContactStruct Contact { get; set; }
    	public bool Condition{ get; set; }
    
    	public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    	{
    		var instance = validationContext.ObjectInstance as MyModel;
    		if (instance == null)
    		{
    			yield break;
    		}
    		if (instance.Condition)
    		{
    			if (instance.Contact == null)
    			{
    				yield return new ValidationResult("contact is required", new string[] { "Contact" });
    			}
    			else
    			{
    				if (string.IsNullOrEmpty(instance.Contact.phone))
    				{
    					yield return new ValidationResult("the phone of contact is required", new string[] { "Contact.phone" });
    				}
    			}
    		}
    	}
    }

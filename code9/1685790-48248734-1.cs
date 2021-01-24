    public class HiresController : RenderMvcController
    {
    	// GET: Hire
    	public ActionResult Hires(RenderModel model)
    	{
    		HireItemsRepo repo = new HireItemsRepo();
    		var VM = repo.PopulateHireItemViewModel(model);
    
    	    return CurrentTemplate("Hires", VM)
    	}
    }

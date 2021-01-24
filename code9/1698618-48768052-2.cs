    public class TwitterViewComponent : ViewComponent
    {
    	public async Task<IViewComponentResult> InvokeAsync(string parameter)
    	{
    		...
    		return View(tweets);
    	}
    }

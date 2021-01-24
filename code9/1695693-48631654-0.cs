    public class SampleController : Controller
    {
         public IActionResult Index() => new View("...", ...);
    
         public IActionResult SubmitSample(string location)
         {
              var model = service.GetLabLocations(location);
              return View("...", model);
         }
    }

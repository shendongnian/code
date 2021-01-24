    public controller MyController : Controller{
    
    private IMyStuff _ms;
    public MyController(IMyStuff ms)
    {
        _ms = ms;
    }
    
    [HttpGet]
    public ActionResult Whatever(){
        var cached = _ms.VeryImportantStringHere; // cached now has the value.
        return View();
        }
    }

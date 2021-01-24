    public class AaController : Controller
    {
        private IRService rService;
    
        public AaController(IRService rService)
        {
            this.rService=rService;
        }
    
        public IActionResult Index()
        {
            int countVal = this.rService.GetRDataCount(234); // pass actual PId
    
            ViewBag.rrData = countVal;
    
            return View();
        }    
    }

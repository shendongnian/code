    public class CompactDiskController : Controller
    {
        public CompactDisk Cd { get; }   
    
        public CompactDiskController()
        {
            this.Cd = new CompactDisk("Abbey Road", "The Beatles");
        }
                
        public ActionResult Index()
        {
            return View(this.Cd);
        }
    
        public ActionResult List()
        {
            return View(this.Cd);
        }
    }

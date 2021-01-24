    public class MyController : ApiController
    {
        private readonly DBFeedbackContext _context;
        public MyController(DBFeedbackContext context)
        {
            _context = context;
        }
    
        public ActionResult Search()
        {
            ViewBag.CMC = _context.Categories.Select(x => new SelectListItem() { Text = x, Value = x.Id.ToString() }).ToList();
            return View();
        }
        
        private ActionResult View(){ ... }
    }

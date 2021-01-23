    public class TransactionController 
    {
        public ActionResult Index()
        {
           return View("List", yourList);
        }
        [HttpGet]
        public ActionResult New(int? id)
        {
           var model = new Model();
           if(id.HasValue)
           {
               model = Get(id.Value);
           }
           return View("New", model);
        }
     }

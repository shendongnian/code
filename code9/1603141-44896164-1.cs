    public class ComplaintController
    {
        [HttpGet]
        public ActionResult Index()
        {
          FeedBack OBJFeedback = new FeedBack();    
           return View(OBJFeedback); 
        }
    }

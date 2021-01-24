    public class SupportingChannelController : Controller
    {
        List<SupportingChannel> _list = null;
        SupportingChannelBL _bl = new SupportingChannelBL();
        // other class-level fields
    
        // returns view to render DataTable
        public ActionResult GetChannelData()
        {
             return View();
        }
    
        // returns JSON data from list of model values
        public ActionResult GetSupportingChannelData()
        {
             // other stuff
    
             _list = _bl.channel();
    
             // other stuff
    
             return Json(new { data = _list }, JsonRequestBehavior.AllowGet);
        }
    }

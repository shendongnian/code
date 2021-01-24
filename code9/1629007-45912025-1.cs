    public class APIController : Controller
    {
        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            dynamic mymodel = new ExpandoObject();
            SegmentRepository segment = new SegmentRepository();
            mymodel.listofSegments = segment.GetSegmentation();
            String roleValue1 = formCollection["Segmentation"];
    
            return View(mymodel);
        }
    }

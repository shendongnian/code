    public class AssetsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UpdateStatus(string uniqueId, string statusId)
        {
            try
            {
                if (true)
                {
                    return Json(new ReturnMsgDefault { type = "success", title = "Success", msg = "Enquiry status changed successfully." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new ReturnMsgDefault { type = "error", title = "Failed", msg = "Enquiry status change failed!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception exc)
            {
                return Json(new ReturnMsgDefault { type = "error", title = "Error occurred", msg = exc.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
    public class ReturnMsgDefault
    {
        public string type { get; set; }
        public string title { get; set; }
        public string msg { get; set; }
    }

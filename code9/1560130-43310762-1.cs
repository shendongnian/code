    public class ValidationController : Controller 
    {
        public JsonResult CheckValidIP(string clientIP) 
        {
            //your validation code here
            if (!_repository.AllowIp(clientIP))
                return Json(true, JsonRequestBehavior.AllowGet);
            else
                return Json(false, JsonRequestBehavior.AllowGet);
        }
    }

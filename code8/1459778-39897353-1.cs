    public class HubspotController : Controller
    {
        [HttpPost]
        public ActionResult FreeDemo(string json)
        {
            JObject jobject = JObject.Parse(json);
    
            var password = jobject["person"]["password"]?.ToString();
            var username = jobject["person"]["username"]?.ToString();
    
            if (!AuthorizeUser(password, username))
            {
                return StatusUnauthorized();
            }
    
            var resultStatus = new ResultStatus { Message = "success"};
            return Json(resultStatus, JsonRequestBehavior.AllowGet);
        }
    
        public ActionResult StatusUnauthorized()
        {
            return new HttpStatusCodeResult((int)HttpStatusCode.Unauthorized, "Unauthorized");
        }
    
        private bool AuthorizeUser(string password, string username)
        {
            return false;
        }
    }

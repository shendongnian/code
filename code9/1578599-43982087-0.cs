    public class MyController : Controller
    {
        [HttpGet]
        public ActionResult GetUsers()
        {
            try
            {
                // Lot of fancy server code ...
    
                throw new ArgumentException("Dummy error");
    
                // Normal return of result ...
    
            }
            catch (Exception ex)
            {
                return Json(new { error = $"{ex.GetType().FullName}: '{ex.Message}'" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
  

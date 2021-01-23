    public ActionResult ThrowJsonError(Exception ex)
    {
       Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
       Response.StatusDescription = ex.Message; // does not work
       Response.StatusDescription = ex.Message.Replace('\r', ' ').Replace('\n', ' '); // works
    
       return Json(new { Message = ex.Message }, JsonRequestBehavior.AllowGet);
    }

    public ActionResult NewControllerAction(string strMessage)
    {
       if(!string.IsNullOrWhiteSpace(strMessage) && strMessage.Equals("Success"))
        {
           HttpPostedFileBase myFile = TempData["FileData"] as HttpPostedFileBase;
        }
        else
        {
           //Something went wrong.
        }
    }

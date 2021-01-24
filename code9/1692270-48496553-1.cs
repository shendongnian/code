    public JsonResult SessionInfo()
        {
    
            if (Session["LoginUserName"]==null)
            {
                 return Json(true);
            }
                 return Json(false);
        }

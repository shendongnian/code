    public JsonResult SessionInfo()
            {
    
                if (Session["LoginUserName"] == null)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }

    public ActionResult ActionName()
            {
                return View(); //Create view for this action
            }
    public JsonResult AjaxActionName()
            {
                return Json(new { status = false, message = "Unauthorized access." }, JsonRequestBehavior.AllowGet);
    
            }

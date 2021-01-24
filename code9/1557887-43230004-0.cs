    [HttpGet]
    [ActionName("GetAllUsers")]
    public ActionResult GetAllUsers()
    {
        var data = ctx.zsp_select_allusers().ToList();
        return Json(data, JsonRequestBehavior.AllowGet);
    }

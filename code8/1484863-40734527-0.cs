    [HttpPost]
    public JsonResult GetUserTraj()
    {
        if (Session["UserName"] != null)
        {
            var userTrajList = DBManager.Instance.GetUserTraj(Session["UserName"].ToString());
            return Json(new { Success = true, Data = userTrajList});
        }
        else
        {
            return Json(new { Success = false, Message = "Session Expired"});
        }
    }

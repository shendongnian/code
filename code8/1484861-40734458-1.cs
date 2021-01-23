       [HttpPost]
    public JsonResult GetUserTraj()
    {
        if (Session["UserName"] != null)
        {
            var userTrajList =
                DBManager.Instance.GetUserTraj(Session["UserName"].ToString());
            return Json(userTrajList);
        }
        else
        {
            //RedirectToAction("Login", "Login");
            return Json(new {code=1});
        }
    }

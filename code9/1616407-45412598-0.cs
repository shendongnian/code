    [HttpPost]
    public ActionResult Login(UserInfo user)
    {
        Session["UserId"] = user.Id;
    }
    
    [HttpPost]
    public ActionResult NewLesson(DersAtamaModel model)
    {
       int userId = Convert.ToInt32(Session["UserId"]);
    }

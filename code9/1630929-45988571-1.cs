    if (ModelState.IsValid)
    {
        using (DB_Entities db = new DB_Entities())
        {
            var obj = db.UserProfiles.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
            if (obj != null)
            {
                Session["UserID"] = obj.UserId.ToString();
                Session["UserName"] = obj.UserName.ToString();
                return RedirectToAction("UserDashBoard");
            }       
            else
            {
                ModelState.AddModelError("", "Invalid Credentials");
            }
        }
    }

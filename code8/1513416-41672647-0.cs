public ActionResult Login(AspNetUser user)
        {
            using (eMediCareDBEntities db = new eMediCareDBEntities())
            {
                //byte[] temp = Convert.FromBase64String("AEh/kUSTE019aDWRoSscnT0c/XArWnjMyBeIgQ1MgTAqRetiD84KgdkFAgHO/bfFKQ==");
    
                //bool result = VerifyHashedPassword(temp, user.PasswordHash);
    
                var v = db.AspNetUsers.FirstOrDefault(a => a.UserName == user.UserName);
                if(v != null &&  v.VerifyHashedPassword(Convert.FromBase64String(a.PasswordHash), user.PasswordHash))
                {
                    Session["Id"] = v.Id.ToString();
                    Session["UserName"] = v.UserName.ToString();
                    return RedirectToAction("Main");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong.");
                }
            }
            return View();
        }</code></pre>

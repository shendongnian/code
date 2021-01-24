        [HttpPost]
        public ActionResult Authenticate(Stories u)
        {
            if (basicOps.getUsersLogin(u.UserName, u.Password)) 
            {
               u.UserID = 90099;
               //your view and controller are bound so no need to specify the view name, just pass the model back
               return View(u);
            }
            return View(u);
        }

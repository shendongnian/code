        public ActionResult changepassword(string ObjId)
        {
            var user = db.Users.Where(c => c.Id == ObjId).SingleOrDefault();
            if (user == null)
            {
                ViewData["isEdit"] = false;
                return PartialView("UsersEditPartialFormView", new User());
            }
            ViewData["isEdit"] = true;
            return PartialView("UsersEditPartialFormView", user);
        }

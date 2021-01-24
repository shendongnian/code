    [HttpPost]
        public ActionResult CreateMultiple(List<User> users)
        {
            if (ModelState.IsValid)
            {
                foreach (User oneUser in users)
                {
                        db.Users.Add(oneUser);
                        db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View();
        }

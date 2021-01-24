      public ActionResult Edit(string roleId)
            {
                IdentityRoleView model = new IdentityRoleView();
    
                model.Name = "IdentityRoleViewUser";
                model.Id = "2";
    
                model.Users.Add(new IdentityUser {
                    UserName = "testuser",
                    Id = "1",
                    Email = "test@test.com"
                });
    
                model.Users.Add(new IdentityUser
                {
                    UserName = "testuser2",
                    Id = "2",
                    Email = "test@test2.com"
                });
    
                return View("Edit", model);
            }
    
            [HttpPost]
            public ActionResult Edit(IdentityRoleView model)
            {
                //Your logic
                return RedirectToAction("Index");
            }

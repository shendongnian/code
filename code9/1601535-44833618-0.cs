     if (ModelState.IsValid)
        {
                var pass = db.usp_GeneratePassword(10).ToList();
                model.UserPassword = pass[0];                
                db.mvcUsers.Add(model);
                db.SaveChanges();
                ModelState.Clear();
                model = null;
        }

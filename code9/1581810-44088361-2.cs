    [HttpPost]
        public ActionResult register(Register obj)
        {
            using(var db = new dbdemoEntities())
            {
                var data = new Register()
                {
                    email = obj.email,
                    name = obj.name,
                    password = obj.password,
                    phone_no = obj.phone_no,
                    Role = db.Roles.Single(r=> r.Id == obj.Role.Id)
                };
    
                db.Registers.Add(data);
                db.SaveChanges();
                ViewBag.register = "Your account has been registered!";
            }
    
            return PartialView();
        }

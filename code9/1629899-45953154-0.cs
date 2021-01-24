    [Route("Doctor/EditPacientInfo/{name}")]
        public ActionResult EditPacientInfo(string name)
        {
     
           // string username = "test_pacient@gmail.com"; <-- THIS ACTUALLY WORKS
            string username = name;
            // Fetch the userprofile
            ApplicationUser user = db.Users.FirstOrDefault(u => u.UserName.Equals(username));
            ViewBag.Email = user.Email;
            // Construct the viewmodel
            ApplicationUser model = new ApplicationUser()
            {          
                PacientInfo = user.PacientInfo
            };
            return View(model);
        }

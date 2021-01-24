    [HttpPost]
            public ActionResult Index(User user)
            {
                if(!ModelState.IsValid)
                { 
                   return View("Index",user);
                }
                 
                // your code here if model is valid
                return View("Index");
            }

     [HttpPost]      
     public ActionResult AddStories(Stories st, HttpPostedFileBase files)
     {
            try
            {
                if (!ModelState.IsValid)
                     return View(st);
                [...] // rest of the codes
            }
     }

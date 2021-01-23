    [HttpPost]
        public ActionResult invform(InfoFormEmplModel form)
        {
            if (ModelState.IsValid)
            {
                //set an error when the id exists    
                ModelState.AddModelError("supId", "The Id is already in use. Please chose a different Id");
                return View(form);
            }
            
            return View(form);
        }

        [HttpPost]
        public ActionResult Save(MyViewModel formModel)
        {
            if (this.ModelState.IsValid)
            {
                // To save the message you will need to save in something like a tempdata, because they ViewBag will lost the value when the page redirect.
                TempData["myMessage"] = "My message.";
                // So you will clear your form and prevent data recess.
                return this.RedirectToAction("MyGETAction");
            }
            // You need to return the view here to show validation messages if you have.
            return View(formModel)
        }

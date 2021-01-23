            [HttpPost]
            public ActionResult ContactUs(string Name, string Email, string Message, string Address)
            {
                ContactusMessages contactUs = new ContactusMessages();
                contactUs.Name = Name;
                contactUs.Email = Email;
                contactUs.Phone = "---";
                contactUs.Message = Message;
                contactUs.IPAddress = Address;
                contactUs.IsSeen = false;
                contactUs.DateAdded = DateTime.Now;
                db.ContactusMessages.Add(contactUs);
                db.SaveChanges();
                ModelState.Clear();
                return Json("success", JsonRequestBehavior.AllowGet);
               // return RedirectToAction("Index", "HomeEn");
    
            }

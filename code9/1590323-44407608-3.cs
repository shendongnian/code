    public ActionResult editContact(int? id)
        {
                var databaseModel = new database();
                if (id == null)
                {
                    return RedirectToAction("Index");
               }
            var contact = databaseModel.displayContact(id);
            return View(contact);
        }

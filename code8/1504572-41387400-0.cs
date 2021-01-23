    public ActionResult Classes(ClassesViewModel model)
    {
        ClassDeclarationsDBEntities1 entities = new ClassDeclarationsDBEntities1();
        if (ModelState.IsValid)
        {
            return RedirectToAction("ClassesPickGroup", "Account", new {    subject_name=model.subject_name});
        }
        else {
          model.subject = entities.Subjects.ToList();
          model.users = entities.Users.ToList();
          return View(model);
        }
    }

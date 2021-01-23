    var entities = new ClassDeclarationsDBEntities1();
    var model = new AddGroupViewModel();
    model.Subjects = entities.Subjects.ToList();
    // set your other properties too?
    return View(model);

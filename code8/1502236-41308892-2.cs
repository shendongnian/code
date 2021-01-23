    public ActionResult MyMarks() {
       ClassDeclarationsDBEntities1 entities = new ClassDeclarationsDBEntities1();
       var model = new MarksModel();
       model.Users = entities.Users.ToList();
       model.NavigationMenuModel = new NavigationMenuModel { UserType = UserType.Admin };
       return View( model );
    }

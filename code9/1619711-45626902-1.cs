    [HttpPost]
    public ActionResult Create(UserViewModel userViewModel)
    { 
       var user = new User();
       var newUser = Mapper.Map(userViewModel, user); 
      _repository.Insert(newUser);
      _repository.Save();
      return View(userViewModel);
    }

             public ActionResult Create(UserViewModel userview)
                {
                    var user= Mapper.Map<User>(userview);
                    var users = _repository.Insert(user); 
                    var userViewModel = Mapper.Map<UserViewModel>(users);
                    return View(userViewModel);
                }

        [HttpPost]
        public ActionResult Create(UserViewModel userViewModel)
        {
            var user = Mapper.Map<User>(userViewModel);
            _reoisitory.Add(user);
        }

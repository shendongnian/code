        [HttpPost("Create")]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
                return BadRequest();
            var result = _usersService.Add(user, m => m.Name == user.Name);
            if (result)
            {
                return CreatedAtRoute("GetUsers", new { id = user.Id }, user);
            }
            return BadRequest("Item not added");
        }
        [HttpPost("CreateAspNetUsers")]
        public IActionResult CreateAspNetUsers([FromBody] RegisterViewModel registerViewModel)
        {
            if (registerViewModel == null)
                return BadRequest();
            var result = _aspNetUsersService.Add(registerViewModel, m => m.Name == registerViewModel.Email);
            if (result)
            {
                return CreatedAtRoute("GetUsers", registerViewModel);
            }
            return BadRequest("Item not added");
        }

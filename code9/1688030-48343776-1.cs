    [HttpGet]
        public IActionResult EditUser(string UserName) {
            var model = new Users(UserName);//probably, Or something like GetUser(UserName)
            return View(model);
        }

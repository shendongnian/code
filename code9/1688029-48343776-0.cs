    [HttpGet]
        public IActionResult EditUser(UserName string) {
            var model = new Users(UserName);//probably, Or something like GetUser(UserName)
            return View(model);
        }

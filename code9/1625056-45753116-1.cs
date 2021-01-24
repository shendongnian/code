        [HttpGet]
        [Authorization]
        public string GetCurrentUsername()
        {
            return UserManager.FindByEmail(User.Identity.Name).Name;
        }

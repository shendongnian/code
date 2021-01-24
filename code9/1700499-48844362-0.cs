    [HttpGet("{id}")]
        public async Task<IActionResult> User(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                //Replace NewUser view name by Appropriate View name in your project
                return View("NewUser");
            }
            else
            {
               var isValidUser= IsValidUser(id);
                if(isValidUser)
                {
                    //Replace ExistingUser view name by Appropriate View name in your project
                    return View("ExistingUser");
                }
                else
                {
                    //User Appropriate overload of NotFound
                    return NotFound();
                }
            }
        }
        private bool IsValidUser(string userId)
        {
            //Your logic to validate the existing user.            
        }

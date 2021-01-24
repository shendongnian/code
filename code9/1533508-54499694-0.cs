         public async Task<IActionResult> Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            { 
                return StatusCode((int)HttpStatusCode.BadRequest, Json("email or password is null")); 
            }
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, Json("Invalid Login and/or password"));
               
            }
            var passwordSignInResult = await _signInManager.PasswordSignInAsync(user, password, isPersistent: true, lockoutOnFailure: false);
            if (!passwordSignInResult.Succeeded)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, Json("Invalid Login and/or password"));
            }
            return StatusCode((int)HttpStatusCode.OK, Json("Sucess !!!"));
        }

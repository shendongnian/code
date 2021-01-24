            [HttpPost]
            [Route("LoginSubmit")]
            public IActionResult LoginSubmit(AllUserViewModels model)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        // If there are no errors upon form submit check db for proper creds.
                        User LoggedUser = _context.Users.SingleOrDefault(u => u.Email == model.Log.Email);
                        var Hasher = new PasswordHasher<User>();
                        // Check    hashed password.
                        if (Hasher.VerifyHashedPassword(LoggedUser, LoggedUser.Password, model.Log.Password) != 0)
                        {
                            // Set user id in session for use in identification, future db calls, and for greeting the user.
                            HttpContext.Session.SetInt32("LoggedUserId", LoggedUser.Id);
                            return RedirectToAction("Account");
                        }
                        else
                        {
                            ViewBag.loginError = "Sorry, your password was incorrect.";
                            return View("landing");
                        }
                    }
                    // If no proper creds redirect to login page and return error.
                    catch
                    {
                        ViewBag.loginError = "Sorry, your email or password were incorrect.";
                        return View("landing");
                    }
                }
                // If form submit was illegal redirect to login and display model validation errors.
                else
                {
                    return View("landing");
                }
            }

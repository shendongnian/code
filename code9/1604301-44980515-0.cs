        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult> LinkLogin([FromBody] ExternalLoginViewModel info)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.GetUserAsync(User);
                if (user != null)
                {
                    IdentityResult result = await userManager.AddLoginAsync(user, new UserLoginInfo(info.LoginProvider, info.ProviderKey, info.LoginProvider));
                    if (result.Succeeded)
                        return Json(true);
                }
            }
            return Json(false);
        }

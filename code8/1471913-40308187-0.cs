        [Authorize(Roles="Administrators")]
        public async Task<IActionResult> ImpersonateUser(string id)
        {
            var appUser = await _userManager.FindByIdAsync(id);
            var userPrincipal = await _signInManager.CreateUserPrincipalAsync(appUser);
            userPrincipal.Identities.First().AddClaim(new Claim("OriginalUserId", User.FindFirst(x=>x.Type == ClaimTypes.NameIdentifier).Value));
            
            await _signInManager.SignOutAsync(); //sign out the current user
            //https://github.com/aspnet/Identity/blob/dev/src/Microsoft.AspNetCore.Identity/IdentityCookieOptions.cs
            await HttpContext.Authentication.SignInAsync("Identity.Application", userPrincipal); //impersonate the new user
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> StopImpersonation()
        {
            var originalUserId = User.Claims.First(x => x.Type == "OriginalUserId").Value;
            var appUser = await _userManager.FindByIdAsync(originalUserId);
            await _signInManager.SignInAsync(appUser, false);
            return RedirectToAction("Index", "Home");
        }

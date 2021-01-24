    public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
           var user =  await _context.Users.FirstOrDefaultAsync(x=>x.Email.Equals(email));
            if(user.LockoutEnd > DateTimeOffset.Now )
            {
                await _signInManager.SignOutAsync();
            }
            if (user.CookieStateHasChanged)
            {
                user.CookieStateHasChanged = false;
                await _userManager.UpdateAsync(user);
                await _signInManager.RefreshSignInAsync(user);
                
            }
            return user;
        }

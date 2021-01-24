    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> RegisterRole(RegisterViewModel model, ApplicationUser user)
    {
        //in case user is being passed in without Id (unlikely), you could use user manager to get the full user object 
        //user = await this.UserManager.FindByNameAsync(user.UserName);
        //get all user's roles, and remove them
        var roles = await this.UserManager.GetRolesAsync(user.Id);
        await this.UserManager.RemoveFromRolesAsync(user.Id, roles.ToArray());
        
        //Assign Role to user here
        await this.UserManager.AddToRoleAsync(user.Id, model.Name);
        return RedirectToAction("Index", "Employee");
    }

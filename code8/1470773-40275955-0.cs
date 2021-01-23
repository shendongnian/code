    public async Task<ActionResult> ConfirmEmail(string userId, string code)
    {
        if (userId == null || code == null)
        {
            return View("Error");
        }
        var result = await UserManager.ConfirmEmailAsync(userId, code);
        //var user = UserManager.FindById(User.Identity.GetUserId());
        var user = UserManager.FindById(userId); //use the received parameter to get the user
        await UserManager.SendEmailAsync(userId, "API", "API Code is: " + user.ApiCode);
    
        return View(result.Succeeded ? "ConfirmEmail" : "Error");
    }

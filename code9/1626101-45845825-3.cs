    public async Task<ActionResult> Login(vmAccountLogin model, string ReturnUrl) {
        // if problems with model, just redisplay form
        if (!ModelState.IsValid) {
            return View(model);
        }
        // hangs on this line
        var user = await UserManager.FindByEmailAsync(model.Email);
        // if user not found for this email, abort with no clues
        if (user == null)
        //...code removed for brevity

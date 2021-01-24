    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        currentUser = await userManager.GetUserAsync(actionContextAccessor.ActionContext.HttpContext.User);
        isAdmin = await userManager.IsInRoleAsync(currentUser, "admin");
    }

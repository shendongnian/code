    public async Task<IViewComponentResult> InvokeAsync()
    {
         _userManager.GetUserId(Request.HttpContext.User);
        return View();
    }

    public void AddErrors(ModelStateDictionary modelState,IdentityResult result)
    {
        foreach (var error in result.Errors)
        {
            modelState.AddModelError(string.Empty, error.Description);
        }
    }

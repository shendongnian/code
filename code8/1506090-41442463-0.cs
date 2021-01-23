    [HttpPost]
    [AllowAnonymous]
    public ActionResult Login(Guid userId, UserType userType)
    {
        try{
         //Your logic 
         return View(new {isSuccess = true, userFullName = account.FullName});
        }
        catch (BusinessExceptions.CannotConnectToCrmServiceException ex)
        {
            ElmahManager.Log(ex);
            return View(new { isSuccess = false, errorText = ErrorMessages.GeneralError });
        }
        catch (Exception exception)
        {
            ElmahManager.Log(exception);
            return View(new { isSuccess = false, errorText = ErrorMessages.GeneralError });
        }
    }

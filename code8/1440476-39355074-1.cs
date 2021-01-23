    public class AccountController : Controller
    {
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if(loginInfo.Email == null)
            {
                 return RedirectToAction("FacebookError", "Account");
            }
            /*my sign in code*/
        }  
    }   
        

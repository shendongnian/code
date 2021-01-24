         [Authorize(AuthenticationSchemes = "MainCookie")]
         public async Task<IActionResult> Contact()
        {
           //Only authenticated users are allowed.
        }
         

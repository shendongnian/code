        if ()
        {
            HttpContext.GetOwinContext()
                .Authentication.Challenge(new AuthenticationProperties {RedirectUri = "/"},
                   "AADLogin");
        }
        else
        {
            HttpContext.GetOwinContext()
               .Authentication.Challenge(new AuthenticationProperties { RedirectUri = "/" },
                  "B2CLogin");
        }

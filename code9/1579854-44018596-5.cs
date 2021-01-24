        var username = Configuration["username"];
        var password = Configuration["password"];
        if (authUser.Username == username && authUser.Password == password)
        {
          var identity = new ClaimsIdentity(claims, 
              CookieAuthenticationDefaults.AuthenticationScheme);
          HttpContext.Authentication.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(identity));
          return Redirect("~/Home/Index");
        }
        else
        {
          ModelState.AddModelError("","Login failed. Please check Username and/or password");
        }

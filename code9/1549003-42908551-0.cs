    var User = System.Web.HttpContext.Current.User;
                if (User.IsInRole("DOMAIN\\ADGroup"))
                {
                    return RedirectToAction("UnAuthorized");
                }

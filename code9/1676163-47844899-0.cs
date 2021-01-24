            if (user != null)
            {
                //FormsAuthentication.SetAuthCookie(user.UserName,true); Remove it
                var authTicket = new FormsAuthenticationTicket(1, user.UserName, DateTime.Now, DateTime.Now.AddHours(24), true, user.Roles);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                Session["Name"] = user.Name;
                return RedirectToAction("Index", "Student");
            }

     protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if (Membership.ValidateUser(Login1.UserName, Login1.Password) == true)
            {
                Login1.Visible = true;
                Session["user"] = User.Identity.Name;
                var userRoles = Roles.GetRolesForUser(Login1.UserName);
                var userIdentity = new GenericIdentity(Login1.UserName);
                var principal = new GenericPrincipal(userIdentity, userRoles);
                Context.User = principal;
                if (User.IsInRole("Admin"))
                    Response.Redirect("~/ThePageForAdmin");
                if (User.IsInRole("User"))
                    Response.Redirect("~/ThePageForUser");
                if (User.IsInRole("Customer"))
                    Response.Redirect("~/ThePageForCustomer");
            }
            else
            {
                Response.Write("Invalid Login");
            }
        }

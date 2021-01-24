         if (User.Identity.IsAuthenticated)
         {
            Response.Redirect("/login.aspx", true);        
         }
         else
         {
            String currentUserName = Use User.Identity.Name; // accessing the logged in uer
            userRoles = Roles.GetRolesForUser(currentUserName); // not sure about this step, have you added your roles to web.Config? or from where you get them
         }

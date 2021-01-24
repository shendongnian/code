    var userroles = Roles.GetRolesForUser(HttpContext.Current.User.ToString());
        if (c.role_available.Split(',').Any(cr => userroles.Any(ru => ru.RoleName== cr)))
                        {
                            
                                (this.Page.FindControl(c.controlid)).Visible = true;                     
                        } 
        else{ 
           (this.Page.FindControl(c.controlid)).Visible = false;
        }

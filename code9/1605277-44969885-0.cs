        protected void FormsAuthentication_OnAuthenticate(Object sender, FormsAuthenticationEventArgs e)
        {
            if (FormsAuthentication.CookiesSupported == true)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        //let us take out the username now                
                        string Email = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                        string roles = string.Empty;
                        using (DatabaseContext entities = new DatabaseContext())
                        {
                            var user = entities.TblUsers.Where(u => u.Email == Email).FirstOrDefault().IDRole;
                       
                            //here
                            roles = entities.TblRoles.Where(x => x.IDRole == user).FirstOrDefault().RoleName;
                        }
                        //let us extract the roles from our own custom cookie
                        // and here
                        //Let us set the Pricipal with our user specific details
                        e.User = new System.Security.Principal.GenericPrincipal(
                          new System.Security.Principal.GenericIdentity(Email, "Forms"), roles.Split(';'));
                     
                    }
                    catch
                    {
                    
                        //somehting went wrong
                    }
                }
            }
        }

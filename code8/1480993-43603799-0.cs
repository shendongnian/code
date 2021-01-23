    public void AuthenticateUser(string userName, string password)
        {
            DirectoryUserAuthenticationResponse response = new DirectoryUserAuthenticationResponse();
            try
            {
                // Creating Principal Context.
                using (var principalContext = GetPrincipalContext())
                {
                    try
                    {
                        // Getting user identity and validating user against active provider.
                        var aUser = UserPrincipal.FindByIdentity(principalContext, GetIdentitytype(), userName);
                        if (aUser != null)
                        {
                            // To check user account is locked out or not
                            if (aUser.IsAccountLockedOut())
                                throw new Exception("UserAccountLockedOut");
                            // To check user account is disabled or not.
                            if (aUser.Enabled == false)
                                throw new Exception("UserAccountDisabled");
                            // To check user change password on next logon.
                            if (aUser.LastPasswordSet == null)
                                throw new Exception("changePassword");
                            //To check password expiration
                            if (aUser.LastPasswordSet != null && aUser.PasswordNeverExpires == false)
                            {
                                DirectoryEntry rootDSE = new DirectoryEntry("LDAP://" + _directoryServerInfo.IPAddress, userName, password);
                                try
                                {
                                    // Bind to the ADsobject to force authentication
                                    object nativeobject = rootDSE.Name;
                                }
                                catch (DirectoryServicesCOMException cex)
                                {
                                    string errorCode = cex.ExtendedErrorMessage.Substring(cex.ExtendedErrorMessage.IndexOf("data", 1));
                                    errorCode = errorCode.Substring(5, 3);
                                    //The commented code below fails to parse properly and throws an exception 
                                    // int exErrorCode = int.Parse(errorCode);
                                    int exErrorCode = int.Parse(Regex.Match(errorCode, @"\d+").Value);
                                    if (exErrorCode == (int)PWDFlags.Account_Expired)
                                        throw new Exception("AccountExpired");
                                    if (exErrorCode == (int)PWDFlags.Password_Expiration)
                                        throw new Exception("PasswordExpired");
                                }
                            }
                            // validate the credentials by using principal context method.
                            var isAuthenticated = principalContext.ValidateCredentials(userName, password);
                            if (!isAuthenticated)
                            {
                                throw new Exception("Invalid your name and passowrd");
                            }
                        }
                        else
                            throw new Exception("InvalidUsernamePassword");
                    }
                    catch (DirectoryServicesCOMException cex)
                    {
                        string errorCode = cex.ExtendedErrorMessage.Substring(cex.ExtendedErrorMessage.IndexOf("data", 1));
                        errorCode = errorCode.Substring(5, 3);
                        //The commented code below fails to parse properly and throws an exception 
                        // int exErrorCode = int.Parse(errorCode);
                        int exErrorCode = int.Parse(Regex.Match(errorCode, @"\d+").Value);
                        if (exErrorCode == (int)PWDFlags.Account_Expired)
                            throw new Exception("AdminACCExpire");
                        if (exErrorCode == (int)PWDFlags.Password_Expiration)
                            throw new Exception("AdminPWDExprire");
                        else
                        {
                          //Else any exception
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }
       private PrincipalContext GetPrincipalContext()
        {
           
            // Creating Principal Context.
            PrincipalContext principalContext = null;
            string serveraddress = _directoryServerInfo.IPAddress;//+":"+_defdirectoryport ;
            if (string.IsNullOrEmpty(_directoryfilterouname))
            {
                principalContext = new PrincipalContext(ContextType.Domain, serveraddress, _directoryAdminUserId, _directoryAdminPassword);
                //principalContext = new PrincipalContext(ContextType.Domain, _directoryServerInfo.IPAddress , _directoryAdminUserId, _directoryAdminPassword);
            }
            else
            {
                //string domainComponents = GetDomainComponents();
                principalContext = new PrincipalContext(ContextType.Domain, serveraddress, _directoryfilterouname, _directoryAdminUserId, _directoryAdminPassword);
            }
            //// _directoryServerInfo.HostName = //((System.DirectoryServices.AccountManagement.ADStoreCtx)(principalContext.QueryCtx)).DnsDomainName;
            return principalContext;
        }

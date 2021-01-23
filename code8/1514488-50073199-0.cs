                 var ldapDomainName= "LDAP://ldap.xserver.net";
                 var loginId = "testUser";
                 var password = "aa1111";
                           // assign user
                            var uid = "uid=" + loginId.Trim() + ",ou=People,dc=servicenginebd,dc=net";
                            // assign password
                            var passwordLdap = password;
                            // define LDAP connection
                            var root = new DirectoryEntry(
                                ldapDomainName, uid, passwordLdap,
                                AuthenticationTypes.None);
                            try
                            {
                                var connected = root.NativeObject;
                                 return "LDAP Login SUCCESSFUL";
                                //isValid = true;
                                // no exception, login successful
                            }
                            catch (Exception ex)
                            {
                                // exception thrown, login failed
                                return "LDAP Login FAILED";
                            }

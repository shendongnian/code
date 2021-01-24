    ConnectionOptions cOption = new ConnectionOptions();
                    ManagementScope scope = null;
                    Boolean isLocalConnection = isLocalhost(machine);
                    
                    if (isLocalConnection)
                    {
                        scope = new ManagementScope(nameSpaceRoot + "\\" + managementScope, cOption);
                    }
                    else
                    {
                        scope = new ManagementScope("\\\\" + machine + "\\" + nameSpaceRoot + "\\" + managementScope, cOption);
                    }
    
                    if (!String.IsNullOrEmpty(ACTIVE_DIRECTORY_USERNAME) && !String.IsNullOrEmpty(ACTIVE_DIRECTORY_PASSWORD) && !isLocalConnection)
                    {
                        scope.Options.Username = ACTIVE_DIRECTORY_USERNAME;
                        scope.Options.Password = ACTIVE_DIRECTORY_PASSWORD;
                    }
                    scope.Options.EnablePrivileges = true;
                    scope.Options.Authentication = AuthenticationLevel.PacketPrivacy;
                    scope.Options.Impersonation = ImpersonationLevel.Impersonate;
                    scope.Connect();

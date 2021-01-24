    public void ShutdownRemotePC(string ipAddress, string adminName, string adminPassword)
            {
    			try
                {
                    var query = new SelectQuery("Win32_OperatingSystem");
    
                    // create always a new management scope
                    // create a default one and get immediate info if connection is be possible
                    ConnectionOptions connectionOptions = new ConnectionOptions
                    {
                        Impersonation = ImpersonationLevel.Impersonate,
                        EnablePrivileges = true,
                        //changed to packet privacy as some service requires it
                        Authentication = AuthenticationLevel.PacketPrivacy,
                        Username = ipAddress + @"\" + adminName,
                        Password = adminPassword,
                        Timeout = TimeSpan.FromMilliseconds(5000)
                    };
                    string name = @"\\" + ipAddress + @"\root\cimv2";
                    ManagementScope managementScope = new ManagementScope(name, connectionOptions);
    
                    // if already connected is checked inside connect
                    managementScope.Connect();
                    if( !managementScope.IsConnected )
                    {
                        //Shutdown Failed. Managment Scope could not be connected.
                        return;
                    }
    
                    using( var searcher = new ManagementObjectSearcher(managementScope, query) )
                    {
                        // impersonate the searcher if not allready done 
                        searcher.Scope.Options.Impersonation = System.Management.ImpersonationLevel.Impersonate;
                        searcher.Scope.Options.EnablePrivileges = true;
    
                        using( ManagementObjectCollection found = searcher.Get() )
                        {
                            foreach( ManagementObject os in found )
                            {
                                // Obtain in-parameters for the method
                                using( ManagementBaseObject inParams = os.GetMethodParameters("Win32Shutdown") )
                                {
    
                                    // Add the input parameters.
                                    inParams["Flags"] = 12;
    
                                    // Execute the method and obtain the return values.
                                    using( ManagementBaseObject outParams = os.InvokeMethod("Win32Shutdown", inParams, null) )
                                    {
                                        if( outParams != null )
                                        {
                                            var result = Convert.ToInt32(outParams["returnValue"]);
                                            if( result == 0 )
                                            {
                                                Logger.LogError("Shutdown successfully.");
                                            }
    
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch( Exception ex )
                {
                    // Shutdown PC=failed.
                }
    		}
